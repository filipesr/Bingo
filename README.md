# Bingo

Dois programas de desktop em C# para partidas de bingo presenciais: um sorteia os números, outro acompanha as cartelas e marca os acertos. Windows Forms sobre .NET Framework 4.5.

## Os dois programas

A solução (`Bingo.sln`) reúne dois executáveis independentes, pensados para rodar em máquinas diferentes durante a mesma partida.

### BingoSorteio
Sorteia os números e mantém na tela o que já saiu. Fica com quem conduz a partida.

### BingoCartela
Acompanha várias cartelas ao mesmo tempo. A cada número digitado, marca a posição correspondente em todas as cartelas carregadas e mostra quantos acertos cada uma tem — por exemplo `Cartela A-4 (5/15)`. Quem confere não precisa varrer cartela por cartela a cada número cantado.

As cartelas são lidas de `lstCartelas.txt`, um arquivo de texto simples: dá para editar em qualquer lugar e recarregar sem recompilar.

## Stack

| Camada | Tecnologia |
| --- | --- |
| Linguagem | C# |
| Plataforma | .NET Framework 4.5 |
| Interface | Windows Forms |
| Dados | Arquivo de texto (`lstCartelas.txt`) |
| Build | Visual Studio (`Bingo.sln`) |

Sem banco e sem instalador: são dois `.exe` que rodam direto.

## Compilando

Abra `Bingo.sln` no Visual Studio e compile a solução. Cada projeto gera seu próprio executável:

- `Bingo/` → **BingoCartela**
- `BingoSorteio/` → **BingoSorteio**

## Histórico

Projeto de 2018, mantido no portfólio como registro de trabalho em C# e aplicação desktop. Não recebe alterações desde então e não pretende recebê-las.
