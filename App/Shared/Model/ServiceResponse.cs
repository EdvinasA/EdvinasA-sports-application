namespace SaveApp;

public class ServiceResponse<T> {

    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public String Message { get; set; } = string.Empty;


}