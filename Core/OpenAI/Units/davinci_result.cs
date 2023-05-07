namespace EasyChatGptBot;

public record class davinci_result
{
    public record class davinci_result_choice
    {
        public record class davinci_result_choice_message
        {
            public string role { get; set; } = string.Empty;
            public string content { get; set; } = string.Empty;
        }
        public int index { get; set; }
        public davinci_result_choice_message? message { get; set; }
        public string finish_reason { get; set; } = string.Empty;
    }
    public record class davinci_result_usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
    public record class davinci_result_error
    {
        public string message { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
    }

    public string id { get; set; } = string.Empty;
    public string @object { get; set; } = string.Empty;
    public int created { get; set; }
    public davinci_result_choice[]? choices { get; set; }
    public davinci_result_usage? usage { get; set; }
    public davinci_result_error? error { get; set; }
}