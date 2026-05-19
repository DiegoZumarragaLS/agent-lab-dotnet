# Instrucciones para agentes de Copilot

## Objetivo del repositorio
- Este proyecto implementa Soc Ops, una app Blazor WebAssembly para un bingo social.
- Punto de entrada principal: [SocOps/Program.cs](../SocOps/Program.cs).
- Flujo principal de UI: [SocOps/Pages/Home.razor](../SocOps/Pages/Home.razor).

## Comandos de trabajo
- Requisito: .NET SDK 10 o superior.
- Ejecutar en desarrollo: dotnet run --project SocOps/SocOps.csproj
- Compilar: dotnet build SocOps/SocOps.csproj

## Arquitectura que debes respetar
- Estado y orquestación del juego en [SocOps/Services/BingoGameService.cs](../SocOps/Services/BingoGameService.cs).
- Reglas puras del bingo en [SocOps/Services/BingoLogicService.cs](../SocOps/Services/BingoLogicService.cs).
- Componentes UI en [SocOps/Components](../SocOps/Components).
- Modelos en [SocOps/Models](../SocOps/Models).
- Banco de preguntas en [SocOps/Data/Questions.cs](../SocOps/Data/Questions.cs).

## Convenciones del proyecto
- Mantener separación de responsabilidades:
  - Lógica de negocio pura en BingoLogicService.
  - Cambios de estado, persistencia y eventos en BingoGameService.
- La persistencia del estado usa localStorage (clave con versión). Si cambias el contrato del estado, considera versionado y compatibilidad.
- Para cambios visuales, reutiliza utilidades CSS existentes y añade nuevas utilidades de forma consistente en [SocOps/wwwroot/css/app.css](../SocOps/wwwroot/css/app.css).

## Guía de diseño
- Priorizar una estética clara, cohesionada y con intención. Evita resultados genéricos o "AI slop".
- Definir un sistema visual coherente con variables CSS para colores, superficies, radios, sombras y estados.
- Elegir una dirección visual concreta antes de tocar componentes: sobrio corporativo, editorial, premium, lúdico, etc.
- Usar tipografía, espaciado y jerarquía visual para dar identidad; no depender solo de colores.
- Añadir profundidad con gradientes, capas o patrones discretos cuando el diseño lo permita.
- Mantener animaciones breves y funcionales; priorizar una animación principal bien resuelta sobre muchas microinteracciones.
- En pantallas o componentes nuevos, empezar por entry points y estados principales antes de refinar detalles secundarios.
- Consultar y respetar la guía de diseño frontend en [.github/instructions/frontend-design.instructions.md](instructions/frontend-design.instructions.md) y las utilidades CSS del proyecto en [.github/instructions/css-utilities.instructions.md](instructions/css-utilities.instructions.md).

## Guías existentes que debes consultar
- Contexto general: [README.md](../README.md).
- Flujo de laboratorio: [workshop/GUIDE.md](../workshop/GUIDE.md).
- Diseño frontend creativo: [.github/instructions/frontend-design.instructions.md](instructions/frontend-design.instructions.md).
- Utilidades CSS del proyecto: [.github/instructions/css-utilities.instructions.md](instructions/css-utilities.instructions.md).

## Cómo validar cambios antes de cerrar una tarea
- Ejecuta dotnet build SocOps/SocOps.csproj.
- Si tocas comportamiento de juego o UI principal, ejecuta dotnet run --project SocOps/SocOps.csproj y verifica flujo Start -> Playing -> Bingo.
- Evita introducir cambios en archivos de build generados (bin/ y obj/).

## Estilo de contribución para el agente
- Realiza cambios pequeños y enfocados.
- Prioriza correcciones sin romper el flujo principal.
- Si hay varias opciones de implementación, elige la más simple que preserve la arquitectura actual.
