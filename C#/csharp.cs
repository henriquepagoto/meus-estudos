// ╔══════════════════════════════════════════════════════════════════╗
// ║              APRENDA C# EM UM ARQUIVO                           ║
// ║   Guia didático e de referência rápida para a linguagem C#      ║
// ╚══════════════════════════════════════════════════════════════════╝

// COMENTÁRIOS EM C#
// Comentários de linha única: use duas barras //
// Tudo após '//' na mesma linha é ignorado pelo compilador.

/*
   Comentários de múltiplas linhas:
   Use /* para abrir e * / para fechar.
   Útil para desativar blocos de código ou escrever explicações longas.
*/

/// <summary>
/// Comentário XML de documentação: use três barras ///.
/// IDEs como o Visual Studio exibem esse texto como dica (tooltip) ao
/// passar o mouse sobre o método ou classe. Ferramentas como o Sandcastle
/// ou DocFX podem gerar documentação HTML a partir desses comentários.
/// </summary>
// public void ExemploDeDocumentacao() {}

// ─────────────────────────────────────────────────────────────────────────────
// NAMESPACES (IMPORTAÇÕES)
// A diretiva 'using' importa um namespace, tornando suas classes disponíveis
// sem precisar escrever o caminho completo (ex: System.Console.WriteLine → Console.WriteLine).
// Os namespaces abaixo fazem parte da biblioteca padrão do .NET Framework.
// ─────────────────────────────────────────────────────────────────────────────

using System;                   // Console, Math, Exception, DateTime, etc.
using System.Collections.Generic; // List<T>, Dictionary<TKey,TValue>, etc.
using System.Dynamic;           // ExpandoObject (objetos dinâmicos)
using System.Linq;              // Métodos de extensão LINQ (.Where(), .Select(), etc.)
using System.Net;               // WebRequest, WebResponse
using System.Threading.Tasks;   // Parallel, Task (programação assíncrona/paralela)
using System.IO;                // StreamWriter, StreamReader (leitura/escrita de arquivos)

// Este namespace NÃO é padrão do .NET — requer instalação via NuGet:
//   PM> Install-Package EntityFramework
// O NuGet é o gerenciador de pacotes do .NET (semelhante ao npm do Node.js).
using System.Data.Entity;

// ─────────────────────────────────────────────────────────────────────────────
// NAMESPACE DO PROJETO
// Namespaces organizam o código em "módulos" lógicos, evitando conflito de nomes.
// Para usar as classes deste arquivo em outro arquivo, adicione:
//   using Learning.CSharp;
// ─────────────────────────────────────────────────────────────────────────────

namespace Learning.CSharp
{
    /// <summary>
    /// Classe principal de exemplos da linguagem C#.
    /// Cada método público demonstra um conjunto de funcionalidades.
    /// </summary>
    /// <remarks>
    /// Por convenção, cada arquivo .cs deve conter uma classe com o mesmo nome do arquivo.
    /// Embora seja tecnicamente permitido ter nomes diferentes, siga essa convenção
    /// para manter o projeto organizado e fácil de navegar.
    /// </remarks>
    public class AprenderCsharp
    {
        // ═════════════════════════════════════════════════════════════════════
        //  SEÇÃO 1: SINTAXE BÁSICA — TIPOS E VARIÁVEIS
        // ═════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Demonstra a sintaxe básica do C#: saída no console, tipos primitivos,
        /// strings, arrays, listas e operadores.
        /// </summary>
        public static void Syntax()
        {
            // ── SAÍDA NO CONSOLE ──────────────────────────────────────────────
            // Console.WriteLine imprime uma linha e adiciona uma quebra de linha no final (\n).
            Console.WriteLine("Hello World");
            Console.WriteLine(
                "Integer: " + 10 +
                " Double: " + 3.14 +
                " Boolean: " + true);

            // Console.Write imprime sem adicionar quebra de linha ao final.
            // As duas linhas abaixo produzem: "Hello World" na mesma linha.
            Console.Write("Hello ");
            Console.Write("World");

            // ─────────────────────────────────────────────────────────────────
            // TIPOS PRIMITIVOS E VARIÁVEIS
            //
            // Sintaxe de declaração:  <tipo> <nome> = <valor>;
            //
            // C# é uma linguagem de tipagem estática e forte:
            //   - Estática: o tipo é definido em tempo de compilação.
            //   - Forte: não há conversão implícita entre tipos incompatíveis.
            // ─────────────────────────────────────────────────────────────────

            // sbyte → inteiro de 8 bits COM sinal. Intervalo: -128 a 127.
            sbyte fooSbyte = 100;

            // byte → inteiro de 8 bits SEM sinal. Intervalo: 0 a 255.
            // Use quando tiver certeza de que o valor nunca será negativo.
            byte fooByte = 100;

            // short → inteiro de 16 bits COM sinal. Intervalo: -32.768 a 32.767.
            // ushort → versão SEM sinal.          Intervalo: 0 a 65.535.
            short fooShort = 10000;
            ushort fooUshort = 10000;

            // int → inteiro de 32 bits COM sinal. Intervalo: -2.147.483.648 a 2.147.483.647.
            // É o tipo inteiro mais comum em C# — usado como padrão para contadores, índices, etc.
            int fooInt = 1;

            // uint → versão SEM sinal do int. Intervalo: 0 a 4.294.967.295.
            uint fooUint = 1;

            // Literais inteiros sem sufixo são inferidos como int ou uint conforme o tamanho do valor.

            // long → inteiro de 64 bits COM sinal. Intervalo: ±9,2 × 10^18.
            // Use o sufixo 'L' para indicar ao compilador que o literal é do tipo long.
            long fooLong = 100000L;

            // ulong → versão SEM sinal do long. Intervalo: 0 a 18,4 × 10^18.
            ulong fooUlong = 100000L;

            // double → ponto flutuante de 64 bits (precisão dupla, padrão IEEE 754).
            // Precisão: 15 a 16 dígitos significativos. Tipo padrão para números decimais em C#.
            double fooDouble = 123.4;

            // float → ponto flutuante de 32 bits (precisão simples, padrão IEEE 754).
            // Precisão: ~7 dígitos. Use o sufixo 'f' para marcar o literal como float.
            // Ocupa metade da memória do double, mas com menos precisão.
            float fooFloat = 234.5f;

            // decimal → tipo de 128 bits com altíssima precisão decimal.
            // Ideal para valores monetários e financeiros, onde erros de arredondamento
            // de ponto flutuante são inaceitáveis. Use o sufixo 'm'.
            decimal fooDecimal = 150.3m;

            // bool → representa verdadeiro (true) ou falso (false).
            // Usado em condições, flags e expressões lógicas.
            bool fooBoolean = true;

            // char → um único caractere Unicode de 16 bits. Use aspas simples.
            char fooChar = 'A';

            // string → sequência de caracteres. É um TIPO DE REFERÊNCIA (diferente dos anteriores,
            // que são tipos de valor). Strings são imutáveis em C#: uma vez criadas, não podem
            // ser modificadas. Qualquer operação que "altera" uma string cria uma nova instância.
            // Sequências de escape comuns: \" (aspas), \n (nova linha), \t (tabulação), \\ (barra invertida).
            string fooString = "\"escapa\" aspas e adiciona \n (novas linhas) e \t (tabulações)";
            Console.WriteLine(fooString);

            // Acesso a caracteres individuais via indexador (índice começa em 0).
            char charFromString = fooString[1]; // => 'e'
            // ATENÇÃO: fooString[1] = 'X' causaria erro de compilação — strings são imutáveis!

            // Comparação de strings com controle de cultura e capitalização.
            // StringComparison.CurrentCultureIgnoreCase ignora maiúsculas/minúsculas.
            string.Compare(fooString, "x", StringComparison.CurrentCultureIgnoreCase);

            // Formatação de strings com string.Format.
            // {0} e {1} são espaços reservados substituídos pelos argumentos seguintes.
            // {1:0.0} formata o segundo argumento com uma casa decimal.
            string fooFs = string.Format("Verificação, {0} {1}, {0} {1:0.0}", 1, 2);

            // Formatação de datas: "hh" = hora 12h, "MM" = mês, "dd" = dia, "yyyy" = ano.
            DateTime fooDate = DateTime.Now;
            Console.WriteLine(fooDate.ToString("hh:mm, dd MMM yyyy"));

            // String verbatim (@"..."): ignora sequências de escape — a barra invertida é literal.
            // Útil para caminhos de arquivo (ex: @"C:\Users\nome") e textos de múltiplas linhas.
            // Para incluir aspas duplas dentro de uma string verbatim, use duas aspas: "".
            string bazString = @"Aqui temos algum texto
em uma nova linha! ""Uau!"", as massas gritaram";

            // const → valor calculado e fixado em TEMPO DE COMPILAÇÃO. Não pode ser alterado.
            // readonly → valor atribuído em tempo de execução (na declaração ou no construtor).
            // Use const para "magic numbers" e configurações que nunca mudam.
            const int HorasTrabalhoSemana = 40;

            // ─────────────────────────────────────────────────────────────────
            // ESTRUTURAS DE DADOS
            // ─────────────────────────────────────────────────────────────────

            // ARRAY (Vetor/Matriz)
            // - Tamanho fixo, definido na criação. Não pode ser redimensionado depois.
            // - Índice começa em 0. Acesso muito rápido por índice (O(1)).
            // Sintaxe: <tipo>[] <nome> = new <tipo>[<tamanho>];
            int[] intArray = new int[10]; // cria array com 10 posições, todas iniciadas com 0

            // Inicialização direta com valores conhecidos:
            int[] y = { 9000, 1000, 1337 };

            // Acessando elementos:
            Console.WriteLine("intArray @ 0: " + intArray[0]); // 0 (valor padrão do int)
            intArray[1] = 1; // arrays são mutáveis — você pode alterar seus elementos

            // LIST<T> (Lista genérica)
            // - Tamanho dinâmico: cresce automaticamente conforme itens são adicionados.
            // - Mais flexível que arrays, mas com leve custo de memória.
            // Sintaxe: List<tipo> nome = new List<tipo>();
            List<int> intList = new List<int>();

            // Sintaxe simplificada (C# 12+): o compilador infere o tipo automaticamente.
            List<int> intListSimplificada = [];

            List<string> stringList = new List<string>();

            // Inicializando uma lista com valores:
            List<int> z = new List<int> { 9000, 1000, 1337 };

            // Listas não têm valores padrão — você precisa adicionar itens antes de acessá-los.
            intList.Add(1);
            Console.WriteLine("intList @ 0: " + intList[0]); // 1

            // Outras estruturas de dados importantes no .NET:
            // ┌─────────────────┬─────────────────────────────────────────────────────┐
            // │ Stack<T>        │ Pilha — Last In, First Out (LIFO)                   │
            // │ Queue<T>        │ Fila  — First In, First Out (FIFO)                  │
            // │ Dictionary<K,V> │ Mapa de chave→valor com busca O(1) por hash         │
            // │ HashSet<T>      │ Conjunto sem duplicatas, busca O(1)                 │
            // │ Tuple           │ Agrupa múltiplos valores sem criar uma classe (.NET 4+)│
            // └─────────────────┴─────────────────────────────────────────────────────┘

            // ─────────────────────────────────────────────────────────────────
            // OPERADORES
            // ─────────────────────────────────────────────────────────────────
            Console.WriteLine("\n-> Operadores");

            int i1 = 1, i2 = 2; // Declaração múltipla em uma linha (use com moderação)

            // Aritmética básica: +  -  *  /
            Console.WriteLine(i1 + i2 - i1 * 3 / 7); // => 3

            // Módulo (%): retorna o RESTO da divisão inteira. Muito útil para verificar
            // paridade (n % 2 == 0 → par) ou criar ciclos (índice % tamanho).
            Console.WriteLine("11%3 = " + (11 % 3)); // => 2

            // Operadores relacionais (de comparação) — sempre retornam bool:
            Console.WriteLine("3 == 2? " + (3 == 2)); // false — igual a
            Console.WriteLine("3 != 2? " + (3 != 2)); // true  — diferente de
            Console.WriteLine("3 > 2? "  + (3 > 2));  // true  — maior que
            Console.WriteLine("3 < 2? "  + (3 < 2));  // false — menor que
            Console.WriteLine("2 <= 2? " + (2 <= 2)); // true  — menor ou igual a
            Console.WriteLine("2 >= 2? " + (2 >= 2)); // true  — maior ou igual a

            // Operadores bit a bit (Bitwise) — operam diretamente nos bits do valor:
            // ┌─────┬──────────────────────────────────────────────────────────┐
            // │  ~  │ Complemento unário: inverte todos os bits (~5 = -6)      │
            // │ <<  │ Deslocamento à esquerda: multiplica por potência de 2    │
            // │ >>  │ Deslocamento à direita: divide por potência de 2         │
            // │  &  │ AND bit a bit: 1 somente se ambos os bits forem 1        │
            // │  ^  │ XOR bit a bit: 1 somente se os bits forem diferentes     │
            // │  |  │ OR  bit a bit: 1 se pelo menos um dos bits for 1         │
            // └─────┴──────────────────────────────────────────────────────────┘

            // Incremento e Decremento:
            // i++ (pós-incremento): usa o valor atual, DEPOIS incrementa.
            // ++i (pré-incremento): incrementa PRIMEIRO, depois usa o novo valor.
            int i = 0;
            Console.WriteLine("\n-> Incremento/Decremento");
            Console.WriteLine(i++); // exibe 0, depois i vira 1
            Console.WriteLine(++i); // i vira 2, exibe 2
            Console.WriteLine(i--); // exibe 2, depois i vira 1
            Console.WriteLine(--i); // i vira 0, exibe 0

            // ─────────────────────────────────────────────────────────────────
            // ESTRUTURAS DE CONTROLE DE FLUXO
            // ─────────────────────────────────────────────────────────────────
            Console.WriteLine("\n-> Estruturas de Controle");

            // IF / ELSE IF / ELSE
            // Executa blocos de código condicionalmente.
            // Sintaxe: if (condição) { } else if (condição) { } else { }
            int j = 10;
            if (j == 10)
            {
                Console.WriteLine("Eu sou exibido"); // j é exatamente 10
            }
            else if (j > 10)
            {
                Console.WriteLine("Eu não sou exibido"); // j não é maior que 10
            }
            else
            {
                Console.WriteLine("Eu também não sou exibido"); // j não é menor que 10
            }

            // OPERADOR TERNÁRIO: versão compacta de um if/else de atribuição.
            // Sintaxe: <condição> ? <valor_se_verdadeiro> : <valor_se_falso>
            // Use apenas para expressões simples — prefira if/else para lógicas complexas.
            int toCompare = 17;
            string isTrue = toCompare == 17 ? "Verdadeiro" : "Falso";

            // WHILE (Enquanto)
            // Executa o bloco ENQUANTO a condição for verdadeira.
            // A condição é verificada ANTES de cada iteração.
            // Se a condição já for falsa no início, o bloco nunca executa.
            int fooWhile = 0;
            while (fooWhile < 100)
            {
                fooWhile++; // incrementa até chegar a 100 (executa 100 vezes: 0→99)
            }

            // DO-WHILE
            // Semelhante ao while, mas a condição é verificada DEPOIS de cada iteração.
            // Isso garante que o bloco seja executado PELO MENOS UMA VEZ.
            int fooDoWhile = 0;
            do
            {
                if (false)
                    continue; // 'continue' pula o restante do bloco e vai para a próxima iteração

                fooDoWhile++;

                if (fooDoWhile == 50)
                    break; // 'break' interrompe o laço completamente
            } while (fooDoWhile < 100);

            // FOR
            // O laço mais explícito: inicialização, condição e passo são declarados juntos.
            // Sintaxe: for (<inicialização>; <condição>; <passo>) { }
            // Ideal quando se sabe exatamente quantas vezes iterar.
            for (int fooFor = 0; fooFor < 10; fooFor++)
            {
                // Executa 10 vezes: fooFor vai de 0 a 9
            }

            // FOREACH (Para Cada)
            // Itera sobre qualquer coleção que implemente IEnumerable ou IEnumerable<T>.
            // Sintaxe: foreach (<Tipo> <variável> in <coleção>) { }
            // Vantagem: mais legível que o for quando não precisa do índice.
            // Todas as coleções do .NET (Array, List, Dictionary...) suportam foreach.
            foreach (char character in "Hello World".ToCharArray())
            {
                // 'character' recebe cada letra de "Hello World" a cada iteração
            }

            // SWITCH / CASE (Escolha por Caso)
            // Compara uma variável com múltiplos valores constantes.
            // Mais legível que uma cadeia longa de if/else if para comparações de igualdade.
            // Funciona com: byte, short, char, int, string, enum e tipos correspondentes.
            // IMPORTANTE: cada case deve terminar com 'break' (ou return/throw).
            int month = 3;
            string monthString;
            switch (month)
            {
                case 1:
                    monthString = "Janeiro";
                    break;
                case 2:
                    monthString = "Fevereiro";
                    break;
                case 3:
                    monthString = "Março";
                    break;
                // Múltiplos cases podem compartilhar o mesmo bloco de código (fall-through vazio):
                case 6:
                case 7:
                case 8:
                    monthString = "Verão!";
                    break;
                // 'default' é executado quando nenhum case corresponde (equivale ao 'else' do if).
                default:
                    monthString = "Outro mês";
                    break;
            }

            // ─────────────────────────────────────────────────────────────────
            // CONVERSÃO DE TIPOS (TYPE CASTING)
            // ─────────────────────────────────────────────────────────────────

            // int.Parse → converte uma string para int.
            // Lança FormatException se a string não representar um número válido.
            int.Parse("123"); // retorna 123

            // int.TryParse → versão segura do Parse.
            // Retorna false em caso de falha (em vez de lançar exceção).
            // O valor convertido é atribuído via parâmetro 'out'.
            // Use TryParse quando a entrada vem do usuário ou de fontes não confiáveis.
            int tryInt;
            if (int.TryParse("123", out tryInt))
                Console.WriteLine(tryInt); // 123

            // Convertendo int para string:
            Convert.ToString(123); // usando a classe utilitária Convert
            tryInt.ToString();     // usando o método da própria instância (preferido)

            // Conversão explícita (cast): força a conversão entre tipos compatíveis.
            // CUIDADO: pode causar perda de dados (ex: truncamento de decimais).
            // Aqui, 15M (decimal) é convertido para int (perde a parte decimal),
            // e depois é implicitamente promovido para long (sem perda).
            long x = (int) 15M; // (int)15M = 15, depois 15 → long = 15L
        }


        // ═════════════════════════════════════════════════════════════════════
        //  SEÇÃO 2: CLASSES E ORIENTAÇÃO A OBJETOS
        // ═════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Demonstra o uso de classes, instanciação de objetos, chamada de métodos
        /// e herança com as classes Bicycle e PennyFarthing.
        /// </summary>
        public static void Classes()
        {
            // 'new' aloca memória e chama o construtor da classe para criar um objeto.
            Bicycle trek = new Bicycle();

            // Chamando um método da instância:
            trek.SpeedUp(3);

            // Atribuindo uma propriedade (o compilador chama o setter internamente):
            trek.Cadence = 100;

            // ToString() (e métodos similares como Info()) são convenções para
            // representar o estado de um objeto como texto legível.
            Console.WriteLine("Informações da trek: " + trek.Info());

            // PennyFarthing herda de Bicycle — o construtor recebe cadência e velocidade inicial.
            PennyFarthing funbike = new PennyFarthing(1, 10);
            Console.WriteLine("Informações da funbike: " + funbike.Info());

            Console.Read();
        }

        // ─────────────────────────────────────────────────────────────────────
        // PONTO DE ENTRADA DA APLICAÇÃO
        // O método Main é o ponto de entrada de qualquer aplicação console em C#.
        // O runtime do .NET procura e executa esse método ao iniciar o programa.
        // O array 'args' contém os argumentos passados pela linha de comando.
        // ─────────────────────────────────────────────────────────────────────
        public static void Main(string[] args)
        {
            OtherInterestingFeatures();
        }

        // ═════════════════════════════════════════════════════════════════════
        //  SEÇÃO 3: CARACTERÍSTICAS AVANÇADAS E INTERESSANTES DO C#
        // ═════════════════════════════════════════════════════════════════════

        // ── ASSINATURAS DE MÉTODOS ────────────────────────────────────────────
        // Um método em C# é composto de: modificador de acesso, tipo de retorno,
        // nome e lista de parâmetros. Essa combinação forma a "assinatura" do método.

        /// <summary>
        /// Demonstra os diferentes elementos de uma assinatura de método em C#,
        /// incluindo parâmetros opcionais e params.
        /// </summary>
        /// <param name="maxCount">Parâmetro obrigatório do tipo int.</param>
        /// <param name="count">Parâmetro opcional — assume 0 se não informado.</param>
        /// <param name="another">Outro parâmetro opcional com valor padrão 3.</param>
        /// <param name="otherParams">Captura qualquer número adicional de strings (params).</param>
        /// <returns>Retorna -1 como valor de exemplo.</returns>
        public         // Modificador de acesso: visível de qualquer lugar
        static         // Pertence à classe, não a uma instância — pode ser chamado sem 'new'
        int            // Tipo de retorno: este método retorna um inteiro
        MethodSignatures(
            int maxCount,             // Parâmetro obrigatório: deve ser sempre fornecido
            int count = 0,            // Parâmetro opcional: usa 0 se não for passado
            int another = 3,          // Outro parâmetro opcional com padrão 3
            params string[] otherParams // 'params': aceita zero ou mais strings extras.
                                        // Deve ser sempre o ÚLTIMO parâmetro.
        )
        {
            return -1;
        }

        /// <summary>
        /// Sobrecarga de MethodSignatures com parâmetros 'ref' e 'out'.
        /// Em C#, métodos podem ter o mesmo nome desde que suas assinaturas sejam diferentes
        /// (tipos e/ou quantidade de parâmetros distintos). Isso se chama SOBRECARGA (overloading).
        /// </summary>
        /// <param name="maxCount">
        /// Passagem por referência (ref): o método pode ler E modificar a variável original.
        /// A variável deve estar inicializada antes de ser passada.
        /// </param>
        /// <param name="count">
        /// Parâmetro de saída (out): o método deve atribuir um valor antes de retornar.
        /// A variável não precisa estar inicializada antes de ser passada.
        /// </param>
        public static void MethodSignatures(
            ref int maxCount,
            out int count)
        {
            count = 15; // 'out' exige que o valor seja atribuído antes do método retornar
        }

        // ── GENÉRICOS (GENERICS) ──────────────────────────────────────────────
        // Genéricos permitem criar métodos e classes que funcionam com qualquer tipo,
        // sem perder a segurança de tipos em tempo de compilação.
        // Os tipos reais (TKey, TValue) são definidos pelo chamador.

        /// <summary>
        /// Retorna o valor associado a uma chave em um dicionário.
        /// Se a chave não existir, insere e retorna o valor padrão informado.
        /// Equivalente ao dict.setdefault(key, default) do Python.
        /// </summary>
        /// <typeparam name="TKey">Tipo da chave do dicionário.</typeparam>
        /// <typeparam name="TValue">Tipo do valor do dicionário.</typeparam>
        /// <param name="dictionary">O dicionário alvo.</param>
        /// <param name="key">A chave a ser buscada.</param>
        /// <param name="defaultItem">Valor a inserir caso a chave não exista.</param>
        /// <returns>O valor existente ou o valor padrão inserido.</returns>
        public static TValue SetDefault<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue defaultItem)
        {
            TValue result;
            if (!dictionary.TryGetValue(key, out result))
                return dictionary[key] = defaultItem;
            return result;
        }

        /// <summary>
        /// Itera e imprime cada elemento de uma coleção de inteiros.
        /// A restrição 'where T : IEnumerable&lt;int&gt;' garante em tempo de compilação
        /// que apenas tipos iteráveis de inteiros sejam aceitos.
        /// </summary>
        /// <typeparam name="T">Deve implementar IEnumerable&lt;int&gt;.</typeparam>
        /// <param name="toPrint">A coleção a ser impressa.</param>
        public static void IterateAndPrint<T>(T toPrint) where T: IEnumerable<int>
        {
            foreach (var item in toPrint)
                Console.WriteLine(item.ToString());
        }

        /// <summary>
        /// Demonstra funcionalidades avançadas do C#: parâmetros opcionais, ref/out,
        /// nullable types, var, generics, lambdas, tratamento de exceções, using,
        /// programação paralela, objetos dinâmicos e LINQ.
        /// </summary>
        public static void OtherInterestingFeatures()
        {
            // ── PARÂMETROS OPCIONAIS E NOMEADOS ───────────────────────────────
            // Parâmetros opcionais podem ser omitidos na chamada.
            MethodSignatures(3, 1, 3, "Alguns", "Parâmetros", "Extras");

            // Parâmetros nomeados permitem pular opcionais intermediários.
            // Aqui, 'count' é pulado e 'another' é definido explicitamente pelo nome.
            MethodSignatures(3, another: 3);

            // ── REF E OUT ─────────────────────────────────────────────────────
            // 'ref' → variável deve estar inicializada; o método pode ler e alterar.
            // 'out' → variável não precisa estar inicializada; o método deve atribuir.
            int maxCount = 0, count;
            MethodSignatures(ref maxCount, out count);

            // ── MÉTODOS DE EXTENSÃO ───────────────────────────────────────────
            // Adicionam métodos a tipos existentes SEM modificar o código original.
            // São definidos como métodos estáticos com 'this' no primeiro parâmetro.
            // Veja a classe 'Extensions' no final deste arquivo.
            int i = 3;
            i.Print(); // aparenta ser um método do int, mas é um método de extensão!

            // ── TIPOS ANULÁVEIS (NULLABLE TYPES) ─────────────────────────────
            // Por padrão, tipos de valor (int, bool, double...) não aceitam null.
            // Adicionar '?' cria um Nullable<T>, que pode representar "sem valor".
            // Muito útil ao trabalhar com dados de banco de dados (campos opcionais).
            int? nullable = null; // equivale a: Nullable<int> nullable = null;
            Console.WriteLine("Variável anulável: " + nullable);

            // .HasValue → true se contiver um valor, false se for null.
            bool hasValue = nullable.HasValue;

            // Operador de coalescência nula (??) → retorna o lado direito se o esquerdo for null.
            // Evita verificações manuais do tipo: nullable != null ? nullable.Value : 0
            int notNullable = nullable ?? 0; // retorna 0, pois nullable é null

            // ── VARIÁVEL COM TIPO IMPLÍCITO (var) ────────────────────────────
            // 'var' não é tipagem dinâmica — o compilador infere o tipo em tempo
            // de compilação. Uma vez inferido, o tipo é fixo (tipagem forte).
            var magic = "magic é uma string em tempo de compilação, com segurança de tipos";
            // magic = 9; → erro de compilação: magic é e sempre será string

            // ── GENÉRICOS NA PRÁTICA ──────────────────────────────────────────
            // Dictionary<TKey, TValue> é uma coleção de pares chave→valor.
            // A busca por chave é O(1) (tempo constante) usando hash internamente.
            var phonebook = new Dictionary<string, string>() {
                {"Sarah", "212 555 5555"}
            };

            // Chamando o método genérico SetDefault definido anteriormente.
            // Aqui os tipos são informados explicitamente <string, string>:
            Console.WriteLine(SetDefault<string,string>(phonebook, "Shaun", "Sem Telefone")); // Sem Telefone
            // O compilador também consegue inferir os tipos automaticamente:
            Console.WriteLine(SetDefault(phonebook, "Sarah", "Sem Telefone")); // 212 555 5555

            // ── EXPRESSÕES LAMBDA ─────────────────────────────────────────────
            // Lambdas são funções anônimas (sem nome) definidas de forma compacta.
            // Sintaxe: (parâmetros) => expressão ou bloco
            // Func<int, int> representa uma função que recebe int e retorna int.
            Func<int, int> square = (x) => x * x;
            Console.WriteLine(square(3)); // 9

            // ── TRATAMENTO DE ERROS (TRY/CATCH/FINALLY) ──────────────────────
            // Use try/catch para lidar com exceções e evitar que o programa encerre
            // abruptamente. O bloco finally sempre é executado, ideal para limpeza.
            try
            {
                // CreateWithGears lança InvalidOperationException internamente
                var funBike = PennyFarthing.CreateWithGears(6);

                // Esta linha nunca será executada (a exceção ocorre antes)
                string some = null;
                some.ToLower(); // NullReferenceException: acesso a referência nula
            }
            catch (NotSupportedException)
            {
                // Captura apenas NotSupportedException — mais específico é melhor
                Console.WriteLine("Sem diversão agora!");
            }
            catch (Exception ex) // Captura qualquer outra exceção não tratada acima
            {
                // Encapsula a exceção original em uma nova com mensagem mais descritiva.
                // Passar 'ex' como innerException preserva a causa raiz para diagnóstico.
                throw new ApplicationException("Deu ruim!", ex);
                // Alternativa: 'throw;' (sem argumento) relança a mesma exceção,
                // preservando o stack trace original — preferível ao 'throw ex;'.
            }
            finally
            {
                // Executa SEMPRE: seja após o try (sem erros) ou após um catch.
                // Ideal para fechar conexões, liberar arquivos ou outros recursos.
            }

            // ── GERENCIAMENTO DE RECURSOS COM 'using' ─────────────────────────
            // O bloco 'using' garante que o método Dispose() seja chamado ao final,
            // liberando recursos não-gerenciados (arquivos, conexões, sockets, etc.).
            // Funciona com qualquer objeto que implemente a interface IDisposable.
            // Equivale a um try/finally com Dispose() no finally — mais conciso.
            using (StreamWriter writer = new StreamWriter("log.txt"))
            {
                writer.WriteLine("Nada de suspeito por aqui");
                // Dispose() é chamado automaticamente aqui, mesmo se houver exceção.
            }

            // ── PROGRAMAÇÃO PARALELA (Parallel.ForEach) ───────────────────────
            // Parallel.ForEach distribui as iterações entre múltiplas threads automaticamente.
            // Use quando as iterações são independentes e a operação é demorada (I/O, CPU-intensiva).
            // Referência: http://blogs.msdn.com/b/csharpfaq/archive/2010/06/01/parallel-programming-in-net-framework-4-getting-started.aspx
            var websites = new string[] {
                "http://www.google.com", "http://www.reddit.com",
                "http://www.shaunmccarthy.com"
            };
            var responses = new Dictionary<string, string>();

            // MaxDegreeOfParallelism limita quantas threads rodam simultaneamente.
            // Sem esse limite, o runtime decide o número de threads automaticamente.
            Parallel.ForEach(websites,
                new ParallelOptions() { MaxDegreeOfParallelism = 3 },
                website =>
                {
                    using (var r = WebRequest.Create(new Uri(website)).GetResponse())
                    {
                        responses[website] = r.ContentType;
                    }
                });

            // Este foreach só executa após TODAS as iterações paralelas terminarem.
            foreach (var key in responses.Keys)
                Console.WriteLine("{0}:{1}", key, responses[key]);

            // ── OBJETOS DINÂMICOS (dynamic / ExpandoObject) ───────────────────
            // 'dynamic' adia a verificação de tipos para o tempo de EXECUÇÃO (não compilação).
            // ExpandoObject permite adicionar propriedades e métodos dinamicamente em tempo de execução.
            // Útil para interoperar com APIs dinâmicas (COM, JSON, Python via IronPython, etc.).
            // ATENÇÃO: perde a segurança de tipos — erros só aparecem em runtime.
            dynamic student = new ExpandoObject();
            student.FirstName = "Primeiro Nome"; // propriedade criada dinamicamente

            // Adicionando um método dinamicamente via Func<string, string>:
            student.Introduce = new Func<string, string>(
                (introduceTo) => string.Format("Olá {0}, aqui é {1}", introduceTo, student.FirstName));
            Console.WriteLine(student.Introduce("Beth"));

            // ── LINQ (Language Integrated Query) ─────────────────────────────
            // LINQ é uma linguagem de consulta integrada ao C#. Permite filtrar, ordenar
            // e transformar coleções com uma sintaxe fluente e expressiva.
            // Funciona com qualquer IEnumerable<T> e tem provedores para SQL, XML, etc.
            var bikes = new List<Bicycle>();

            // Sort() ordena usando o comparador padrão do tipo.
            bikes.Sort();
            // Sobrecarga com lambda: ordena por número de rodas.
            bikes.Sort((b1, b2) => b1.Wheels.CompareTo(b2.Wheels));

            var result = bikes
                .Where(b => b.Wheels > 3)            // Filter: mantém só bikes com mais de 3 rodas
                .Where(b => b.IsBroken && b.HasTassles) // Filter encadeado (AND lógico)
                .Select(b => b.ToString());           // Map: transforma cada Bicycle em string

            var sum = bikes.Sum(b => b.Wheels); // Reduce: soma todas as rodas

            // Tipo anônimo: cria um objeto temporário sem definir uma classe.
            // O compilador infere o tipo — ótimo para projeções (Select) pontuais.
            var bikeSummaries = bikes.Select(b => new { Name = b.Name, IsAwesome = !b.IsBroken && b.HasTassles });
            foreach (var bikeSummary in bikeSummaries.Where(b => b.IsAwesome))
                Console.WriteLine(bikeSummary.Name);

            // ── PLINQ (Parallel LINQ — AsParallel) ───────────────────────────
            // AsParallel() paraleliza a consulta LINQ automaticamente entre múltiplos cores.
            // Ideal para grandes volumes de dados em máquinas multicore.
            // Use com cuidado: o overhead de paralelização pode ser prejudicial em coleções pequenas.
            var threeWheelers = bikes.AsParallel().Where(b => b.Wheels == 3).Select(b => b.Name);

            // ── LINQ TO SQL (Execução Tardia / Lazy Evaluation) ───────────────
            // Ao usar LINQ com Entity Framework ou LinqToSql, as consultas NÃO são executadas
            // imediatamente. A query é montada como uma expressão e só enviada ao banco
            // quando os dados são realmente necessários (ex: ao iterar com foreach).
            // Isso permite compor filtros dinamicamente sem múltiplas consultas ao banco.
            var db = new BikeRepository();

            // Nenhuma consulta SQL é disparada ainda — apenas a expressão é construída:
            var filter = db.Bikes.Where(b => b.HasTassles);
            if (42 > 6)
                filter = filter.Where(b => b.IsBroken); // ainda sem consulta

            var query = filter
                .OrderBy(b => b.Wheels)
                .ThenBy(b => b.Name)
                .Select(b => b.Name); // ainda sem consulta

            // A consulta SQL é gerada e executada AGORA, durante a iteração:
            foreach (string bike in query)
                Console.WriteLine(bike);
        }

    } // Fim da classe AprenderCsharp


    // ═══════════════════════════════════════════════════════════════════════════
    //  SEÇÃO 4: MÉTODOS DE EXTENSÃO
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Classe estática que contém métodos de extensão para tipos existentes.
    /// Métodos de extensão devem estar em uma classe estática e o primeiro parâmetro
    /// deve usar a palavra-chave 'this' para indicar qual tipo está sendo estendido.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adiciona o método Print() a qualquer objeto do sistema.
        /// Após definido, pode ser chamado como: minhaVariavel.Print()
        /// </summary>
        /// <param name="obj">O objeto cujo ToString() será impresso no console.</param>
        public static void Print(this object obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  SEÇÃO 5: CLASSES — ENCAPSULAMENTO, PROPRIEDADES, HERANÇA
    //
    //  Sintaxe de declaração de classe:
    //  <modificador_acesso> class <NomeDaClasse>
    //  {
    //      // campos, construtores, propriedades e métodos
    //  }
    //
    //  Modificadores de acesso:
    //  ┌───────────────┬──────────────────────────────────────────────────────┐
    //  │ public        │ Acessível de qualquer lugar                          │
    //  │ private       │ Acessível apenas dentro da própria classe            │
    //  │ protected     │ Acessível na classe e em suas subclasses             │
    //  │ internal      │ Acessível apenas dentro do mesmo assembly (.dll/.exe)│
    //  │ protected     │                                                      │
    //  │   internal    │ Combinação: protected OU internal                    │
    //  └───────────────┴──────────────────────────────────────────────────────┘
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Representa uma bicicleta genérica.
    /// Demonstra: propriedades, enums, construtores, métodos virtuais,
    /// membros estáticos, readonly e indexadores.
    /// </summary>
    public class Bicycle
    {
        // ── PROPRIEDADES ──────────────────────────────────────────────────────
        // Propriedades são a forma preferida em C# para expor dados de uma classe.
        // Elas substituem os métodos getXxx()/setXxx() comuns em outras linguagens.
        // Internamente, o compilador gera métodos get e set para cada propriedade.

        /// <summary>Cadência do pedal (rotações por minuto).</summary>
        public int Cadence  // public: qualquer código externo pode ler e escrever
        {
            get { return _cadence; }       // chamado ao ler:  var c = bike.Cadence;
            set { _cadence = value; }      // chamado ao escrever: bike.Cadence = 80;
            // 'value' é a palavra-chave especial que representa o valor atribuído
        }
        private int _cadence; // campo privado de apoio (backing field)

        /// <summary>
        /// Marcha atual. Protected: visível nesta classe e nas subclasses.
        /// Propriedade automática: o compilador cria o backing field automaticamente.
        /// </summary>
        protected virtual int Gear
        {
            get; // propriedade automática — sem backing field manual necessário
            set;
        }

        /// <summary>
        /// Número de rodas. Internal: visível apenas no mesmo assembly.
        /// O setter é private: só a própria classe pode alterar o número de rodas.
        /// </summary>
        internal int Wheels
        {
            get;
            private set; // setter com acesso mais restrito que o getter
        }

        // Campo privado: 'private' é o modificador padrão quando nenhum é especificado.
        int _speed;

        /// <summary>Nome da bicicleta. Propriedade automática pública.</summary>
        public string Name { get; set; }

        // ── ENUM (ENUMERADOR) ─────────────────────────────────────────────────
        // Enum é um tipo de valor que representa um conjunto fixo de constantes nomeadas.
        // Internamente, cada nome mapeia para um número inteiro (padrão: int).
        // Tipos permitidos: byte, sbyte, short, ushort, int, uint, long, ulong.
        // Use enums para substituir "magic numbers" e tornar o código mais legível.

        /// <summary>Marcas de bicicleta disponíveis.</summary>
        public enum BikeBrand
        {
            AIST,        // valor implícito = 0
            BMC,         // valor implícito = 1
            Electra = 42, // valor explícito = 42
            Gitane        // valor implícito = 43 (anterior + 1)
        }
        // Por estar aninhado na classe Bicycle, código externo deve usar: Bicycle.BikeBrand

        /// <summary>Marca da bicicleta.</summary>
        public BikeBrand Brand;

        // ── ENUM COM FLAGS ────────────────────────────────────────────────────
        // [Flags] indica que os valores do enum podem ser COMBINADOS via operador OR bit a bit.
        // Os valores DEVEM ser potências de 2 para que as combinações sejam únicas.
        // Exemplo: Bell | Lights = 1 | 8 = 9 (valor único que identifica exatamente esses dois)

        /// <summary>Acessórios opcionais da bicicleta. Podem ser combinados com |.</summary>
        [Flags]
        public enum BikeAccessories
        {
            None        = 0,  // sem acessórios
            Bell        = 1,  // 0001
            MudGuards   = 2,  // 0010
            Racks       = 4,  // 0100
            Lights      = 8,  // 1000
            FullPackage = Bell | MudGuards | Racks | Lights // 1111 = 15
        }
        // Como verificar: aBike.Accessories.HasFlag(Bicycle.BikeAccessories.Bell)
        // Antes do .NET 4: (aBike.Accessories & Bicycle.BikeAccessories.Bell) == Bicycle.BikeAccessories.Bell

        /// <summary>Acessórios instalados nesta bicicleta.</summary>
        public BikeAccessories Accessories { get; set; }

        // ── MEMBRO ESTÁTICO ───────────────────────────────────────────────────
        // Membros static pertencem ao TIPO, não a uma instância específica.
        // São compartilhados entre todos os objetos da classe.
        // Acesso: Bicycle.BicyclesCreated (não precisa de instância).

        /// <summary>Contador global de bicicletas criadas (compartilhado entre todas as instâncias).</summary>
        public static int BicyclesCreated { get; set; }

        // ── READONLY ──────────────────────────────────────────────────────────
        // readonly: valor definido em tempo de execução, mas só pode ser atribuído
        // na declaração ou dentro de um construtor. Diferente de 'const' (compile-time).
        readonly bool _hasCardsInSpokes = false;

        // ── CONSTRUTORES ──────────────────────────────────────────────────────
        // Construtores inicializam o estado do objeto quando 'new' é usado.
        // Uma classe pode ter múltiplos construtores (sobrecarga).

        /// <summary>
        /// Construtor padrão (sem parâmetros).
        /// Cria uma bicicleta com valores predefinidos.
        /// </summary>
        public Bicycle()
        {
            this.Gear = 1; // 'this' referencia o objeto atual — útil para diferenciar
            Cadence = 50;  // campos de parâmetros com mesmo nome (não obrigatório aqui)
            _speed = 5;
            Name = "Bontrager";
            Brand = BikeBrand.AIST;
            BicyclesCreated++; // incrementa o contador estático a cada instância criada
        }

        /// <summary>
        /// Construtor parametrizado: permite criar bicicletas com configurações customizadas.
        /// ': base()' chama explicitamente o construtor da classe pai (System.Object).
        /// </summary>
        public Bicycle(int startCadence, int startSpeed, int startGear,
                       string name, bool hasCardsInSpokes, BikeBrand brand)
            : base() // chama o construtor de System.Object (implícito — aqui apenas ilustrativo)
        {
            Gear = startGear;
            Cadence = startCadence;
            _speed = startSpeed;
            Name = name;
            _hasCardsInSpokes = hasCardsInSpokes;
            Brand = brand;
        }

        /// <summary>
        /// Construtor encadeado: delega para outro construtor da mesma classe via 'this(...)'.
        /// Evita duplicação de código de inicialização.
        /// </summary>
        public Bicycle(int startCadence, int startSpeed, BikeBrand brand) :
            this(startCadence, startSpeed, 0, "Rodas Grandes", true, brand)
        {
            // O corpo está vazio pois toda a lógica está no construtor delegado acima.
        }

        // ── MÉTODOS ───────────────────────────────────────────────────────────

        /// <summary>Aumenta a velocidade da bicicleta.</summary>
        /// <param name="increment">Quanto aumentar. Padrão: 1.</param>
        public void SpeedUp(int increment = 1)
        {
            _speed += increment;
        }

        /// <summary>Diminui a velocidade da bicicleta.</summary>
        /// <param name="decrement">Quanto diminuir. Padrão: 1.</param>
        public void SlowDown(int decrement = 1)
        {
            _speed -= decrement;
        }

        // Propriedade com backing field manual — equivalente à propriedade automática,
        // mas permite adicionar lógica de validação no getter e/ou setter.
        private bool _hasTassles;

        /// <summary>Indica se a bicicleta tem borlas (tassles) no guidão.</summary>
        public bool HasTassles
        {
            get { return _hasTassles; }
            set { _hasTassles = value; }
        }

        /// <summary>
        /// Indica se a bicicleta está quebrada.
        /// O setter é private: só a própria classe pode marcar a bicicleta como quebrada.
        /// </summary>
        public bool IsBroken { get; private set; }

        /// <summary>
        /// Tamanho do quadro. Somente a classe Bicycle pode alterar este valor (private set).
        /// Código externo pode apenas ler (get público).
        /// </summary>
        public int FrameSize
        {
            get;
            private set;
        }

        // ── INDEXADOR (INDEXER) ───────────────────────────────────────────────
        // Indexadores permitem acessar objetos com a sintaxe de array: objeto[índice].
        // Útil quando a classe representa uma coleção ou sequência de dados.

        private string[] passengers = { "chris", "phil", "darren", "regina" };

        /// <summary>
        /// Acessa os passageiros pelo índice: bike[0] retorna "chris".
        /// Permite também atribuição: bike[1] = "lisa".
        /// </summary>
        public string this[int i]
        {
            get { return passengers[i]; }
            set { passengers[i] = value; }
        }

        // ── MÉTODO VIRTUAL (POLIMORFISMO) ─────────────────────────────────────
        // 'virtual' sinaliza que subclasses PODEM sobrescrever este método com 'override'.
        // Se não for sobrescrito, o comportamento desta implementação é usado.

        /// <summary>Retorna uma string com as informações atuais da bicicleta.</summary>
        public virtual string Info()
        {
            return "Marcha: " + Gear +
                   " Cadência: " + Cadence +
                   " Velocidade: " + _speed +
                   " Nome: " + Name +
                   " Cartas nos raios: " + (_hasCardsInSpokes ? "sim" : "não") +
                   "\n------------------------------\n";
        }

        /// <summary>
        /// Verifica se bicicletas suficientes foram criadas.
        /// Método estático: só acessa membros estáticos da classe.
        /// </summary>
        /// <returns>true se mais de 9000 bicicletas foram criadas.</returns>
        public static bool DidWeCreateEnoughBycles()
        {
            return BicyclesCreated > 9000;
        }

    } // Fim da classe Bicycle

    // ═══════════════════════════════════════════════════════════════════════════
    //  SEÇÃO 6: HERANÇA
    //  PennyFarthing herda de Bicycle — reutiliza código e especializa comportamento.
    //
    //  Regras de herança em C#:
    //  - Uma classe pode herdar de APENAS UMA classe base (herança simples).
    //  - Use ':' para indicar a classe pai: class Filha : Pai { }
    //  - Use 'base' para acessar membros da classe pai.
    //  - Use 'override' para sobrescrever métodos virtuais.
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// PennyFarthing é um tipo especial de bicicleta com roda frontal enorme e sem marchas.
    /// Herda de Bicycle e sobrescreve o comportamento de marchas para lançar exceção.
    /// </summary>
    class PennyFarthing : Bicycle
    {
        /// <summary>
        /// Construtor que repassa os parâmetros ao construtor da classe pai via 'base(...)'.
        /// </summary>
        public PennyFarthing(int startCadence, int startSpeed) :
            base(startCadence, startSpeed, 0, "PennyFarthing", true, BikeBrand.Electra)
        {
        }

        /// <summary>
        /// Sobrescreve a propriedade Gear para impedir a troca de marchas.
        /// PennyFarthings não têm sistema de marchas — qualquer tentativa de definir
        /// uma marcha lança InvalidOperationException.
        /// </summary>
        protected override int Gear
        {
            get { return 0; } // sempre retorna 0 (sem marcha)
            set
            {
                // Lança exceção para sinalizar uso incorreto da API.
                throw new InvalidOperationException("Você não pode mudar as marchas em uma PennyFarthing");
            }
        }

        /// <summary>
        /// Tenta criar uma PennyFarthing com marchas — o que é inválido.
        /// Este método existe para demonstrar o lançamento de exceção via propriedade.
        /// </summary>
        /// <param name="gears">Número de marchas desejado (sempre causará exceção).</param>
        /// <returns>Nunca retorna — sempre lança InvalidOperationException.</returns>
        public static PennyFarthing CreateWithGears(int gears)
        {
            var penny = new PennyFarthing(1, 1);
            penny.Gear = gears; // dispara a exceção definida no setter acima
            return penny;
        }

        /// <summary>
        /// Sobrescreve Info() para incluir a identificação de PennyFarthing.
        /// 'base.ToString()' chama o método ToString() herdado de System.Object.
        /// </summary>
        public override string Info()
        {
            string result = "Bicicleta PennyFarthing ";
            result += base.ToString(); // System.Object.ToString() retorna o nome completo do tipo
            return result;
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  SEÇÃO 7: INTERFACES
    //
    //  Interfaces definem CONTRATOS: "quais membros um tipo deve ter".
    //  Elas NÃO contêm implementação (apenas assinaturas).
    //  Uma classe pode implementar MÚLTIPLAS interfaces (diferente de herança de classe).
    //
    //  Quando usar interface vs classe abstrata?
    //  ┌───────────────────────┬───────────────────────────────────────────────┐
    //  │ Interface             │ Classe Abstrata                               │
    //  ├───────────────────────┼───────────────────────────────────────────────┤
    //  │ Apenas contrato       │ Contrato + implementação compartilhada        │
    //  │ Sem estado            │ Pode ter campos e construtores                │
    //  │ Múltiplas por classe  │ Apenas uma por classe                         │
    //  │ "O que o objeto FAZ"  │ "O que o objeto É + o que ele FAZ"            │
    //  └───────────────────────┴───────────────────────────────────────────────┘
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>Define o comportamento de objetos que podem pular.</summary>
    interface IJumpable
    {
        // Todos os membros de interface são implicitamente public e abstract.
        void Jump(int meters);
    }

    /// <summary>Define o comportamento de objetos que podem quebrar.</summary>
    interface IBreakable
    {
        // Interfaces também podem conter propriedades, eventos e indexadores.
        bool Broken { get; }
    }

    /// <summary>
    /// MountainBike herda de Bicycle E implementa IJumpable e IBreakable.
    /// C# permite herança de apenas UMA classe, mas implementação de MÚLTIPLAS interfaces.
    /// </summary>
    class MountainBike : Bicycle, IJumpable, IBreakable
    {
        int damage = 0; // dano acumulado pelos saltos

        /// <summary>Realiza um salto e acumula dano proporcional à distância.</summary>
        public void Jump(int meters)
        {
            damage += meters;
        }

        /// <summary>
        /// A bicicleta está quebrada se o dano acumulado ultrapassar 100.
        /// Implementação obrigatória da interface IBreakable.
        /// </summary>
        public bool Broken
        {
            get { return damage > 100; }
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  SEÇÃO 8: POLIMORFISMO
    //
    //  Polimorfismo (do grego: "muitas formas") é a capacidade de tratar objetos
    //  de tipos diferentes de forma uniforme através de um tipo base comum.
    //
    //  Como funciona em C#:
    //  1. 'virtual'  → na classe PAI: "este método pode ser sobrescrito".
    //  2. 'override' → na classe FILHA: "substituo o comportamento padrão".
    //  3. Late Binding: o C# decide QUAL método executar em tempo de EXECUÇÃO,
    //     com base no tipo REAL do objeto (não pelo tipo da variável).
    //
    //  Exemplo:
    //    Bicycle minhaBike = new PennyFarthing(1, 10);
    //    Console.WriteLine(minhaBike.Info());
    //    // Executa Info() da PennyFarthing, não da Bicycle!
    //    // Mesmo que a variável seja do tipo Bicycle, o objeto real é PennyFarthing.
    // ═══════════════════════════════════════════════════════════════════════════

    // ═══════════════════════════════════════════════════════════════════════════
    //  SEÇÃO 9: CLASSES ABSTRATAS
    //
    //  Uma classe abstrata é um "molde" incompleto que NÃO pode ser instanciado.
    //  É usada como base para outras classes, impondo que certos membros sejam implementados.
    //
    //  Características:
    //  - Marcada com 'abstract'.
    //  - Métodos 'abstract': sem corpo — as subclasses DEVEM implementar com 'override'.
    //  - Métodos concretos: têm implementação que pode ser herdada diretamente.
    //  - Pode ter campos privados, construtores protegidos e estado.
    //
    //  new Veiculo() → ERRO de compilação (não pode instanciar classe abstrata).
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Classe abstrata que serve como molde base para todos os veículos.
    /// Não pode ser instanciada diretamente — use as subclasses concretas.
    /// </summary>
    public abstract class Veiculo
    {
        /// <summary>Marca do veículo (ex: Toyota, Ford).</summary>
        public string Marca { get; set; }

        /// <summary>Modelo do veículo (ex: Corolla, Fusion).</summary>
        public string Modelo { get; set; }

        /// <summary>
        /// Construtor protegido: só pode ser chamado por subclasses via 'base(...)'.
        /// Garante que toda subclasse forneça marca e modelo ao ser criada.
        /// </summary>
        protected Veiculo(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }

        /// <summary>
        /// Método abstrato: SEM implementação. Cada subclasse concreta
        /// DEVE fornecer sua própria versão usando 'override'.
        /// </summary>
        public abstract void Buzinar();

        /// <summary>
        /// Método concreto: TEM implementação e é herdado por todas as subclasses.
        /// Subclasses podem sobrescrever se precisar de comportamento diferente.
        /// </summary>
        public void Ligar()
        {
            Console.WriteLine($"{Marca} {Modelo} foi ligado e está pronto para rodar!");
        }
    }

    /// <summary>
    /// Classe concreta que herda de Veiculo.
    /// Por ser concreta, DEVE implementar todos os métodos abstratos herdados.
    /// </summary>
    public class Carro : Veiculo
    {
        /// <summary>Cria um novo carro com a marca e modelo informados.</summary>
        public Carro(string marca, string modelo) : base(marca, modelo)
        {
        }

        /// <summary>
        /// Implementação obrigatória do método abstrato Buzinar().
        /// Cada tipo de veículo tem seu próprio som de buzina.
        /// </summary>
        public override void Buzinar()
        {
            Console.WriteLine("Bi-bi! Fom-fom!");
        }
    }

    // ═══════════════════════════════════════════════════════════════════════════
    //  SEÇÃO 10: ENTITY FRAMEWORK E LINQ TO SQL
    //
    //  Entity Framework (EF) é um ORM (Object-Relational Mapper) do .NET.
    //  Ele mapeia classes C# para tabelas de banco de dados, permitindo consultar
    //  e manipular dados usando LINQ em vez de SQL puro.
    //
    //  DbContext → representa a sessão de conexão com o banco de dados.
    //  DbSet<T>  → representa uma tabela (coleção de entidades do tipo T).
    //
    //  Referência: http://msdn.microsoft.com/en-us/data/jj193542.aspx
    // ═══════════════════════════════════════════════════════════════════════════

    /// <summary>
    /// Contexto de banco de dados para bicicletas usando Entity Framework.
    /// Herda de DbContext, que gerencia a conexão, rastreamento de mudanças e transações.
    /// </summary>
    public class BikeRepository : DbContext
    {
        /// <summary>
        /// Construtor padrão: usa a string de conexão definida no App.config/Web.config
        /// com o nome "BikeRepository" (convenção do EF).
        /// </summary>
        public BikeRepository()
            : base()
        {
        }

        /// <summary>
        /// Representa a tabela "Bicycles" no banco de dados.
        /// Use este DbSet para consultar, inserir, atualizar e remover bicicletas.
        /// Exemplo: db.Bikes.Where(b => b.Name == "Trek").ToList()
        /// </summary>
        public DbSet<Bicycle> Bikes { get; set; }
    }

} // Fim do namespace Learning.CSharp
