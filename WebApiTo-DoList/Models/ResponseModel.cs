namespace WebApiTo_DoList.Models;

public class ResponseModel<T>
{
    public T? Dados { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public Boolean Status { get; set; }
}