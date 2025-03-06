using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace IFiles
{
    /// <summary>ファイルの共通的な振る舞いを定義します。</summary>
    public interface IFile
    {
        /// <summary>ファイルの名前を取得または設定します。</summary>
        string Name { get; }
        /// <summary>ファイルのパスを取得または設定します。</summary>
        string Path { get; set; }
        /// <summary>指定したパスのファイルを読み込みます。</summary>
        bool Load(string path = null);
        /// <summary>指定したパスにファイルを保存します。</summary>
        bool Save(string path = null);
    }

    /// <summary>
    /// INIファイルを操作する機能を提供します。
    /// WIN32APIを使用しない為、文字コードセットの指定が可能です。
    /// 
    /// ■仕様
    /// ・セクション無しのキーバリューは無いものとして扱う。
    /// ・キーバリューと同じ行に記載されているコメントは保持する。
    /// ・コメントのみの行は無いものとして扱う。(コメントのみの行があるINIファイルを読込み→保存とした場合、コメントのみの行は削除される。)
    /// ・「;」または「#」以降の行末までの文字をコメントとして扱います。
    /// ・コメントの出力時は「;」として出力します。
    /// </summary>
    public class IniFile : IFile
    {
        #region Constant
        /// <summary>
        /// セクションチェック正規表現パターン
        /// </summary>
        /// 
        private static readonly string SECTION_PATTERN = @"^\s*\[(?<SECTION>[^\[\]]+?)\]\s*$";

        /// <summary>
        /// キー/値チェック正規表現パターン
        /// </summary>
        private static readonly string KEYVALUE_PATTERN = @"^\s*(?<KEY>[^=;#]+?)\s*=\s*(?<VALUE>[^=;#]*?)(;.*|#.*|\s*)$";

        /// <summary>
        /// コメントチェック正規表現パターン
        /// </summary>
        private static readonly string COMMENT_PATTERN = @"^.*(;|#)(?<COMMENT>.*)$";

        /// <summary>
        /// 正規表現グループ セクション
        /// </summary>
        private static readonly string SECTION = "SECTION";

        /// <summary>
        /// 正規表現グループ キー
        /// </summary>
        private static readonly string KEY = "KEY";

        /// <summary>
        /// 正規表現グループ 値
        /// </summary>
        private static readonly string VALUE = "VALUE";

        /// <summary>
        /// 正規表現グループ コメント
        /// </summary>
        private static readonly string COMMENT = "COMMENT";

        /// <summary>
        /// Mapの値を表すキー
        /// </summary>
        private const string KEY_VALUE = "value";

        /// <summary>
        /// Mapのコメントを表すキー
        /// </summary>
        private const string KEY_COMMENT = "comment";
        #endregion

        #region Property
        /// <summary>
        /// INIファイル構造ディクショナリ
        /// </summary>
        private Dictionary<string, Dictionary<string, Dictionary<string, string>>> Map { get; set; }

        /// <summary>
        /// ファイルのエンコーディングを取得します。
        /// </summary>
        public Encoding Encoding { get; private set; }

        /// <summary>
        /// ファイルの名前を取得または設定します。
        /// </summary>
        public string Name => System.IO.Path.GetFileName(Path);

        /// <summary>
        /// ファイルのパスを取得または設定します。
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// コメントの開始文字を取得または設定します。デフォルトは";"です。
        /// 出力時のみ使用されまうす。読込み時のコメント開始文字は";"または"#"が使用可能です。
        /// </summary>
        public string CommentChar { get; set; } = ";";

        /// <summary>
        /// インデクサー
        /// 指定のセクションのキーから値を取得または設定します。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">キー名</param>
        /// <returns></returns>
        public string this[string section, string key]
        {
            get { return GetValue<string>(section, key); }
            set { SetValue(section, key, value); }
        }

        /// <summary>
        /// インデクサー
        /// 指定のセクションのキーから値を取得または設定します。
        /// 取得に失敗した場合、デフォルト値を返却します。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">キー名</param>
        /// <param name="defaultValue">デフォルト値</param>
        /// <returns></returns>
        public string this[string section, string key, string defaultValue]
        {
            get { return GetValue(section, key, defaultValue); }
            set { SetValue(section, key, value); }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 空のINIファイルインスタンスを初期化します。
        /// </summary>
        public IniFile() : this(null, Encoding.UTF8) { }

        /// <summary>
        /// ファイル名を含む絶対パスを指定してINIファイルインスタンスを初期化します。
        /// </summary>
        /// <param name="filePath"></param>
        public IniFile(string filePath) : this(filePath, Encoding.UTF8) { }

        /// <summary>
        /// 文字エンコーディングを指定して空のINIファイルインスタンスを初期化します。
        /// </summary>
        /// <param name="enc"></param>
        public IniFile(Encoding enc) : this(null, enc) { }

        /// <summary>
        /// ファイル名を含む絶対パスと文字エンコーディングを指定してINIファイルクラスインスタンスを初期化します。
        /// </summary>
        /// <param name="filePath">ファイル名を含む絶対パス</param>
        /// <param name="enc">エンコーディング</param>
        public IniFile(string filePath, Encoding enc)
        {
            Path = filePath;
            Encoding = (enc is null) ? Encoding.UTF8 : enc;

            Map = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();

            if (File.Exists(filePath))
            {
                Load(filePath);
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 指定したパスのINIファイルをDictionaryに読み込みます。
        /// </summary>
        /// <param name="path">ファイル名を含む絶対パス</param>
        public bool Load(string path)
        {
            Path = path;

            var lines = new List<string>();

            // 全行取得
            using (var sr = new StreamReader(path, Encoding))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }

            if (!lines.Any()) return true;

            // セクションとキー/値をチェック
            var secRegex = new Regex(SECTION_PATTERN);
            var keyRegex = new Regex(KEYVALUE_PATTERN);
            var commentRegex = new Regex(COMMENT_PATTERN);
            var lastSec = string.Empty;

            foreach (var line in lines)
            {
                // セクション行
                if (secRegex.IsMatch(line))
                {
                    // セクション名取得
                    var section = secRegex.Match(line).Groups[SECTION].Value.Trim();

                    // 読込み済みではないセクションの場合
                    if (!Map.ContainsKey(section))
                    {
                        Map[section] = new Dictionary<string, Dictionary<string, string>>();
                    }

                    // 最終読込みセクションをメモ
                    lastSec = section;
                }
                // キー＆値行
                else if (keyRegex.IsMatch(line))
                {
                    // 最終読込みセクションが空
                    if (string.IsNullOrWhiteSpace(lastSec))
                    {
                        continue;
                    }

                    // キーと値を取得
                    var key = keyRegex.Match(line).Groups[KEY].Value.Trim();
                    var value = keyRegex.Match(line).Groups[VALUE].Value.Trim();

                    // キーと値をセクションに追加
                    Map[lastSec][key] = new Dictionary<string, string>();
                    Map[lastSec][key][KEY_VALUE] = value;

                    // コメント有り
                    if (commentRegex.IsMatch(line))
                    {
                        var comment = commentRegex.Match(line).Groups[COMMENT].Value;
                        Map[lastSec][key][KEY_COMMENT] = comment;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// INIファイルを指定のパスに保存します。
        /// <paramref name="path"/>がnullの場合、インスタンス初期化時のパスに上書き出力します。
        /// </summary>
        /// <param name="path">ファイル名を含む絶対パス</param>
        /// <returns>true:保存成功</returns>
        public bool Save(string path = null)
        {
            var savePath = path;

            if (string.IsNullOrWhiteSpace(savePath))
            {
                // INIファイルが新規作成の場合
                if (string.IsNullOrWhiteSpace(Path))
                {
                    return false;
                }
                // INIファイルを読込んでいる場合
                else
                {
                    savePath = Path;
                }
            }

            using (var fs = new FileStream(savePath, FileMode.Create))
            using (var sw = new StreamWriter(fs, Encoding))
            {
                foreach (var section in Map.Keys)
                {
                    sw.WriteLine($"[{section}]");

                    foreach (var pair in Map[section])
                    {
                        // キーと値を出力
                        var text = $"{pair.Key}={pair.Value[KEY_VALUE]}";

                        if (pair.Value.ContainsKey(KEY_COMMENT))
                        {
                            // コメントを出力
                            text += $"{CommentChar}{pair.Value[KEY_COMMENT]}";
                        }
                        sw.WriteLine(text);
                    }
                }

                sw.Flush();
                fs.Flush();
            }

            return true;
        }

        /// <summary>
        /// セクション名一覧を取得します。
        /// </summary>
        /// <returns>セクション名コレクション</returns>
        public IEnumerable<string> GetSections()
        {
            if (!Map.Any())
            {
                return null;
            }
            else
            {
                return Map.Keys;
            }
        }

        /// <summary>
        /// キー名一覧を取得します。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <returns>キー名コレクション</returns>
        public IEnumerable<string> GetKeys(string section)
        {
            if (!IsSectionExists(section))
            {
                return null;
            }
            else
            {
                return Map[section].Keys;
            }
        }

        /// <summary>
        /// キー名と値のディクショナリを取得します。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <returns>キー名=値のディクショナリ</returns>
        public IDictionary<string, string> GetKeyValuePair(string section)
        {
            if (!IsSectionExists(section))
            {
                return null;
            }
            else
            {
                return Map[section].ToDictionary(m => m.Key, m => m.Value[KEY_VALUE]);
            }
        }

        /// <summary>
        /// INIファイルに指定のセクションが存在するかチェックします。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <returns>true:セクション有/false:セクション無</returns>
        public bool IsSectionExists(string section)
        {
            if (!Map.Any())
            {
                return false;
            }
            else
            {
                return Map.ContainsKey(section);
            }
        }

        /// <summary>
        /// INIファイルの指定のセクションに指定のキー名が存在するかチェックします。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">キー名</param>
        /// <returns>true:キー有/false:キー無</returns>
        public bool IsKeyExists(string section, string key)
        {
            if (!IsSectionExists(section))
            {
                return false;
            }
            else
            {
                return Map[section].ContainsKey(key);
            }
        }

        /// <summary>
        /// INIファイルの指定のセクションの指定のキー名から値を取得します。
        /// 取得に失敗した場合、デフォルト値を返却します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="section">セクション名</param>
        /// <param name="key">キー名</param>
        /// <param name="defVal">デフォルト値</param>
        /// <returns>値</returns>
        public T GetValue<T>(string section, string key, T defVal = default)
        {
            T result = defVal;

            if (!IsKeyExists(section, key))
            {
                return result;
            }

            var val = Map[section][key][KEY_VALUE];
            Type t = typeof(T);

            try
            {
                result = (T)Convert.ChangeType(val, t);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return result;
        }

        /// <summary>
        /// INIファイルの指定のセクションの指定のキー名からコメントを取得します。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">キー名</param>
        /// <returns>コメント</returns>
        public string GetComment(string section, string key)
        {
            if (IsKeyExists(section, key))
            {
                return Map[section][key][KEY_COMMENT];
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// INIファイルの指定のセクションの指定のキー名に値を設定します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="section">セクション名</param>
        /// <param name="key">キー名</param>
        /// <param name="value">設定値</param>
        /// <param name="comment">コメント</param>
        public void SetValue<T>(string section, string key, T value)
        {
            // 存在しないセクションの場合は追加する
            if (!Map.ContainsKey(section))
            {

                Map[section] = new Dictionary<string, Dictionary<string, string>>();
            }

            // 存在しないキーの場合追加する
            if (!Map[section].ContainsKey(key))
            {
                Map[section][key] = new Dictionary<string, string>();
            }

            Map[section][key][KEY_VALUE] = value.ToString();
        }

        /// <summary>
        /// INIファイルの指定のセクションの指定のキー名にコメントを設定します。
        /// </summary>
        /// <param name="section">セクション名</param>
        /// <param name="key">キー名</param>
        /// <param name="comment">コメント</param>
        public void SetComment(string section, string key, string comment)
        {
            if (IsKeyExists(section, key))
            {
                Map[section][key][KEY_COMMENT] = comment;
            }
        }
        #endregion
    }
}