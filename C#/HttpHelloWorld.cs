using System;
using System.Net;
using System.Text;


class Program
{
    static void Main()
    {
        // 1. Crie uma instância do HttpListener
        HttpListener listener = new HttpListener();

        // 2. Define a porta (ex: 8080) e o endereçamento (localhost ou IP)
        // O "*" instrui o .NET a escutar em TODAS as interfaces de rede na porta especificada
        int Porta = 8080;
        listener.Prefixes.Add($"http://*:{Porta}/"); 

        // 3. Inicie o servidor
        try
        {
            Console.WriteLine("Iniciando o servidor!!!");

            listener.Start(); // Inicia a escuta de solicitações

            Console.WriteLine($"Servidor está rodando em http://localhost:{Porta}!");

            while (true) // Loop infinito para manter o servidor ativo
            {
                try
                {
                    // 4. Captura uma solicitação quando um cliente pede
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    // 5. Processa a solicitação (ex: imprime o método e caminho)
                    string metho = request.HttpMethod;
                    string path = request.Url.AbsolutePath;
                    Console.WriteLine($"Recebi uma solicitação {metho} em {path}");

                    // 6. Cria uma resposta simples
                    string content = "Olá, World! Isso é um servidor simples em C#";
                    byte[] buffer = Encoding.UTF8.GetBytes(content);
                    response.ContentLength64 = buffer.Length; // Define a largura do corpo da resposta

                    // 7. environment: envia o corpo da resposta
                    response.OutputStream.Write(buffer, 0, buffer.Length);

                    // 8. Fecha a resposta (o .NET gerencia isso por padrão)
                }
                catch (HttpListenerException ex) // Trata erros como porta já em uso
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inicial: {ex.Message}");
        }
        finally
        {
            listener.Stop(); // Desfica o servidor quando encerrar a aplicação
        }
    }
}

/* 
### **Passo 1: Como Testar o Servidor**
1. **Compilador:** Compile com:
   ```bash
   csc -t exehello World.cs
   ```
   (Se usar .NET Core, alterne para `dotnet build` e `dotnet run`).

2. **Executar:**
   ```bash
   ./exehelloWorld.exe  // No Windows, use o caminho do executable .exe
   ```

3. **Verificar no navegador:**
   - Abaixo: `http://localhost:8080`
   - ou usar ferramentas como [Postman](https://www.postman.com/) para testar solicitações GET/POST.

4. **Exemplo de Saída no Console:**
   ```
   Servidor está rodando em http://localhost:8080!
   Recebi uma solicitação GET em /
   ```

### **Explicação do Código**
- **`HttpListener`:** classe nativa da .NET para criar um servidor HTTP.
- **`new IPEndPoint(IPAddress.Any, 8080)`:** define a porta (8080) e escuta em todos os endpoints de rede.
- **`listener.GetContext()`:** blocka até uma solicitação chegar (em modo sincronizado).
- **`response.ContentLength64 = buffer.Length;`:** define o tamanho do corpo da resposta antes de enviar.
- **`response.OutputStream.Write(...);`:** envia o conteúdo da resposta para o cliente.

---

### **Observações Importantes**
1. **Portas low**: Se usar portas como 80 (HTTP) ou 443 (HTTPS), você precisará ter permissões administrativas em Windows.
2. **Modo assíncrono**: Para não blockar a thread principal, ajuste:
   ```csharp
   listener.PollingContextMode = PollingContextMode.Asynchronous;
   ```
   E use `listener.GetContextAsync()` (em async/await).
3. **Solicitações POST:** Adicione código para lidar com métodos como `POST` e parsear os dados enviados via corpo da solicitação.

---

### **Extensões Básicas**
- **Método HTTP POST:**
  ```csharp
  if (request.HttpMethod == "POST")
  {
      string postData = request.Content.ReadAsStringAsync().Result;
      // Processa o dados do corpo da solicitação
  }
  ```

- **Redirecionamento (3xx):** Crie uma resposta que redireciona para outro endereço.
 */