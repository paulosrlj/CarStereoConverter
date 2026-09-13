# Car Stereo Converter

Aplicativo Windows Forms para converter arquivos de áudio (MP3, WAV, FLAC, M4A, AAC, OGG) para **MP3 320kbps**, sem metadados, prontos para tocar em rádios de carro que só reconhecem MP3 puro.

Versão com interface gráfica do projeto original [mp3-to-car-sound](https://github.com/paulosrlj/mp3-to-car-sound) (script em Ruby).

## Funcionalidades

- Arraste e solte arquivos de áudio direto na janela, ou selecione manualmente.
- Escolha da pasta de saída (a estrutura de pastas original é preservada).
- Conversão para MP3 320kbps via `ffmpeg`, com remoção de metadados e capas de álbum embutidas.
- Barra de progresso por arquivo, em tempo real.
- Botões **Converter**, **Parar** (interrompe a conversão em andamento) e **Limpar** (limpa a lista de arquivos).
- Tela "Sobre" com versão e link do repositório.

## Requisitos

- Windows 10/11 (64-bit).
- [.NET 10 Desktop Runtime](https://dotnet.microsoft.com/download) — necessário apenas se você baixar a versão "framework-dependent" da Release. A versão "self-contained" não exige nada instalado.
- `ffmpeg.exe` e `ffprobe.exe` — **não incluídos no repositório** (veja abaixo).

## Como usar (versão pronta / Release)

1. Baixe o `.zip` mais recente na aba [Releases](../../releases).
2. Extraia em qualquer pasta.
3. Confirme que existe uma subpasta `ffmpeg\` contendo `ffmpeg.exe` e `ffprobe.exe`. Se não existir, baixe o build "essentials" (Windows 64-bit) em [gyan.dev/ffmpeg/builds](https://www.gyan.dev/ffmpeg/builds/) e copie os dois `.exe` (pasta `bin` do zip baixado) para dentro da pasta `ffmpeg\` do programa.
4. Execute o `CarStereoConverter.exe`.

## Como compilar a partir do código-fonte

1. Instale o [Visual Studio 2026](https://visualstudio.microsoft.com/) (ou mais recente) com a carga de trabalho **.NET Desktop Development**.
2. Clone este repositório e abra o `CarStereoConverter.slnx`.
3. Coloque `ffmpeg.exe` e `ffprobe.exe` dentro de `CarStereoConverter/ffmpeg/` (veja o `LEIA-ME.txt` daquela pasta) — o `.csproj` já copia esses arquivos automaticamente para a pasta de saída ao compilar.
4. Compile e execute (F5).

## Estrutura do projeto

```
CarStereoConverter/
├── Form1.cs / Form1.Designer.cs   # Janela principal
├── AboutForm.cs / .Designer.cs    # Janela "Sobre"
├── Models/AudioFile.cs            # Modelo de arquivo em processamento
├── Services/ConversionService.cs  # Chamadas ao ffmpeg/ffprobe
└── ffmpeg/                        # Coloque aqui ffmpeg.exe e ffprobe.exe
```

## Licença e créditos

Este projeto redistribui apenas os binários do [ffmpeg](https://ffmpeg.org/) sem modificá-los; consulte a licença (LGPL/GPL, dependendo do build) no site oficial do projeto.

Autor: Paulo ([@paulosrlj](https://github.com/paulosrlj))
