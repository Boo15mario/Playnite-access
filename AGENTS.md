# Repository Guidelines

## Project Structure & Module Organization

Playnite is a .NET Framework 4.6.2 WPF solution rooted at `source/Playnite.sln`. Core shared code lives in `source/Playnite`, Desktop UI in `source/Playnite.DesktopApp`, Fullscreen UI in `source/Playnite.FullscreenApp`, and public SDK types in `source/PlayniteSDK`. Tests and test fixtures live under `source/Tests`. Build automation is in `build`, binary/reference assets are in `references`, UI/media assets are in `media`, and additional fixture data is in top-level `tests`.

## Build, Test, and Development Commands

Run commands from the repository root on Windows or Windows-backed WSL.

```powershell
pwsh.exe -NoProfile -Command './build/build.ps1 -Configuration Debug -Platform x86'
```

Builds the main Debug x86 output into `build/Debug`, restores packages, validates localization/platform/emulator definitions, and runs MSBuild.

```powershell
pwsh.exe -NoProfile -Command './build/VerifyLanguageFiles.ps1'
```

Checks localization files without running the full build.

Use Visual Studio 2022 Build Tools or Visual Studio 2022 for IDE work. The build requires .NET Framework 4.6.2 Developer Pack.

## Coding Style & Naming Conventions

Use C# 7.3-compatible code unless the target project already allows otherwise. Follow existing WPF/XAML patterns and keep accessibility properties on meaningful controls when editing UI. Use PascalCase for public types, methods, and properties; camelCase for locals and private fields where existing files do. Preserve existing line endings and XML project-file style. `source/.editorconfig` disables selected IDE style suggestions; do not introduce broad formatter churn.

## Testing Guidelines

Tests use NUnit and are organized by project under `source/Tests/*Tests`. Add tests next to the relevant test project, naming files and fixtures after the behavior under test, for example `SerializationTests.cs` or `GamesEditorTests.cs`. Prefer focused regression tests for bug fixes. If a change touches WPF accessibility, also perform manual keyboard and screen-reader checks when possible; automated build success does not prove UI Automation quality.

## Commit & Pull Request Guidelines

Recent history uses short, imperative commit subjects such as `Fixed errors in RALibRetro profiles` or `Updated controller DB file`. Keep commits focused and avoid mixing unrelated refactors with behavior changes. PRs should describe the user-visible change, list verification commands and results, link relevant issues, and include screenshots or screen-reader notes for UI changes. Call out dependency or build-tool changes explicitly.

## Security & Configuration Tips

Do not commit generated build outputs from `build/Debug`, restored package folders, secrets, or local machine paths. Keep intentional dependency pins documented near the configuration that enforces them. For accessibility work, prefer upstream WPF/UI Automation fixes over tool-specific workarounds.
