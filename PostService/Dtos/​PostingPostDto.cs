namespace PostService;

/// <summary>
/// Модель для створення нового поштового відправлення (дата-контракт запиту POST)
/// </summary>
public class PostingPostDto
{
    /// <summary>
    /// ПІБ або найменування відправника
    /// </summary>
    public string Sender { get; set; } = string.Empty;

    /// <summary>
    /// ПІБ або найменування отримувача
    /// </summary>
    public string Receiver { get; set; } = string.Empty;

    /// <summary>
    /// Опис вмісту поштового відправлення
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Вага поштового відправлення у кілограмах
    /// </summary>
    public double Weight { get; set; }
}