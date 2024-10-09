using oai_poc_backend.Data_Transfer_Objects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class PromptSetting
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("setting_id")]
        public int SettingId { get; set; }

        [Column("prompt_id")]
        public int? PromptId { get; set; }

        [Column("template_id")]
        public int? TemplateId { get; set; }

        //Navigation properties
        public SettingModel? Setting { get; set; }
        public PromptModel? Prompt { get; set; }
        public TemplateModel? Template { get; set; }

        public PromptSetting(SettingDto settingDto)
        {
            SettingId = settingDto.Id;
        }
        public PromptSetting()
        {

        }

    }
}
