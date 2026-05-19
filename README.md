🌐 [Português (BR)](README.pt_BR.md) | [Español](README.es.md)

# Soc Ops

> A social bingo web app built with Blazor WebAssembly, designed for in-person mixers and team events.

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/download/dotnet/10.0)
[![Blazor](https://img.shields.io/badge/Blazor-WebAssembly-5C2D91?logo=blazor&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![Live Demo](https://img.shields.io/badge/Live-Demo-00A86B)](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/)
[![Lab Guide](https://img.shields.io/badge/Docs-Lab%20Guide-0A66C2)](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/)

## Why Soc Ops

Soc Ops turns icebreakers into a quick, playful experience.
Players look for people who match each square and race to complete a 5-in-a-row line.

- Built for workshops, bootcamps, team offsites, and community meetups
- Mobile-friendly game flow with instant visual feedback
- Local state persistence so users can continue where they left off

## Live Experience

- Play now: [Live Demo](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/)
- Follow the full hands-on journey: [Lab Guide](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/)
- Read offline materials: [workshop/](workshop/)

## Project Highlights

- Blazor WebAssembly app with clear service boundaries
- Game state orchestration in [SocOps/Services/BingoGameService.cs](SocOps/Services/BingoGameService.cs)
- Pure bingo rules in [SocOps/Services/BingoLogicService.cs](SocOps/Services/BingoLogicService.cs)
- Reusable UI components in [SocOps/Components/](SocOps/Components)
- Centralized question bank in [SocOps/Data/Questions.cs](SocOps/Data/Questions.cs)

## Quick Start

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or higher

### Run locally

```bash
cd SocOps
dotnet run
```

### Build

```bash
cd SocOps
dotnet build
```

## Run in Codespaces (optional)

After creating your own repository from this template:

1. Open the repository on GitHub.
2. Select Code > Codespaces > Create codespace on main.
3. Wait for the devcontainer setup to finish.
4. Run:

```bash
cd SocOps
dotnet run
```

## Lab Roadmap

| Part | Focus |
|------|-------|
| [00](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=00-overview) | Overview and checklist |
| [01](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=01-setup) | Setup and context engineering |
| [02](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=02-design) | Design-first frontend |
| [03](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=03-quiz-master) | Custom Quiz Master |
| [04](https://dotnet-presentations.github.io/vscode-github-copilot-agent-lab/docs/step.html?step=04-multi-agent) | Multi-agent development |

## Repository Structure

- Main app: [SocOps/](SocOps)
- Documentation site assets: [docs/](docs)
- Workshop content: [workshop/](workshop)

## Contributing

Contributions are welcome.

- Contribution guide: [CONTRIBUTING.md](CONTRIBUTING.md)
- Code of conduct: [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md)
- Security policy: [SECURITY.md](SECURITY.md)

## Deployment

The project is deployed to GitHub Pages and updates automatically on pushes to main.
