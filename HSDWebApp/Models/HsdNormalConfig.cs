using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSDWebApp.Models
{
    /// <summary>
    /// HSDノーマルサイズ設定管理用
    /// </summary>
    [DisplayName("HSDノーマルサイズ設定管理用テーブル")]
    [Table("hsd_normal_config")]
    public class HsdNormalConfig
    {
        /// <summary>
        /// 設定に紐づくユーザーID
        /// </summary>
        [Key]
        [DisplayName("設定に紐づくユーザーID")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [Column("user_id", Order = 1)]
        public string UserId { get; set; }

        /// <summary>
        /// パネルナンバー
        /// </summary>
        [Key]
        [DisplayName("パネルナンバー")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [Column("panel_id", Order = 2)]
        public int PanelId { get; set; }

        /// <summary>
        /// 行番
        /// </summary>
        [Key]
        [DisplayName("行番")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [Column("row_number", Order = 3)]
        public int RowNumber { get; set; }

        /// <summary>
        /// 列番
        /// </summary>
        [Key]
        [DisplayName("列番")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [Column("column_number", Order = 4)]
        public int ColumnNumber { get; set; }

        /// <summary>
        /// ボタン名
        /// </summary>
        [DisplayName("ボタン名")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [Column("button_name", Order = 4)]
        public string ButtonName { get; set; }

        /// <summary>
        /// ボタン種別
        /// </summary>
        [DisplayName("ボタン種別")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [Column("button_type", Order = 4)]
        public int ButtonType { get; set; }

        /// <summary>
        /// ボタンコマンド
        /// </summary>
        [DisplayName("ボタンコマンド")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [Column("command_string", Order = 4)]
        public string CommandString { get; set; }

        /// <summary>
        /// ボタンアイコンイメージデータ
        /// </summary>
        [DisplayName("ボタンアイコンイメージデータ")]
        [Column("button_icon_data", Order = 4)]
        public byte[]? ButtonIconData { get; set; }

        /// <summary>
        /// ボタンについてのメモ
        /// </summary>
        [DisplayName("ボタンについてのメモ")]
        [Column("description", Order = 4)]
        public string? Description { get; set; }
        
        /// <summary>
        /// 最終更新日時
        /// </summary>
        [DisplayName("最終更新日時")]
        [Required(ErrorMessage = "{0}は必須です。")]
        [Column("last_update", Order = 4)]
        public DateTime LastUpdate { get; set; }

    }
}
