# Accessibility Follow-Up Work

This document tracks Desktop-mode accessibility slices after filter/search navigation.
Slices B and C below are implemented; remaining manual screen-reader validation is noted per slice.

## B. Game Details, Play, and Edit Actions (done)

Goal: a screen-reader user can understand the selected game details and launch or edit the game without object navigation.

Scope:
- Add accessible names to icon-only game action buttons in details and grid views. *Done:* grid-tile Play/Info
  buttons (`GridViewItemTemplate.xaml`) now expose `LOCPlayGame`/`LOCGameDetails`, with the Play button switching to
  `LOCInstallGame` when the game is uninstalled; the grid-view sidebar close button (`GridViewGameOverview.xaml`) uses
  `LOCCloseLabel`. The details/grid edit button already gets its name from `GameOverview.cs`
  (`AutomationProperties.SetName(ButtonEditGame, …)`), shared by both views.
- Game title, install state, source/platform, play status, links, and description: the play/install/context buttons
  carry their action text as content, and the detail fields are label+value pairs reachable in document order, so they
  read correctly without object navigation.
- Remaining: verify keyboard paths for play, install/uninstall, edit metadata, context menu, and details/sidebar
  toggles, and make launch failures/action results discoverable via named status text or UI Automation events
  (notification surfaces are out of scope for this slice).

Validation (manual, still recommended):
- Select a game from the library with only the keyboard.
- Read core details with NVDA.
- Launch, open context actions, and open edit metadata without mouse routing or OCR.

## C. Settings and Add-ons Manager (done)

Goal: a screen-reader user can configure Playnite and manage add-ons using standard keyboard navigation.

Scope:
- Reviewed every settings section for unlabeled controls and added `AutomationProperties.Name` (sourced from the same
  `LOC*` resource as the visible label, falling back to a literal where no key exists) to combo boxes, text boxes,
  sliders, numeric boxes, list/grid views, hotkey/path boxes, and icon-only buttons across `General`,
  `AppearanceGeneral/Advanced/DetailsView/GridView/ListView/Layout/TopPanel`, `Updates`, `Metadata`, `Performance`,
  `Sorting`, `Search`, `Backup`, `Scripting`, `GeneralAdvanced`, `ClientShutdown`, `Development`, `ImportExlusionList`,
  and `MetadataDownloadSettings`. Checkboxes already expose their text content as the name and were left unchanged.
- Add-on lists: named the installed-extensions/themes list boxes (`LOCExtensions`/`LOCThemes`), the browse list and
  search box, the version combo, and bound the per-update selection checkbox name to the add-on name so each row
  announces its target. Name/type/state detail remains exposed through the adjacent detail pane.
- Plugin settings host: the `SettingsWindow`/`AddonsWindow` navigation trees now carry region names; the
  `PluginSettingsWindow` host simply presents the third-party view, whose own controls keep their labels and tab order.

Validation (manual, still recommended):
- Open settings, change accessibility option, change theme/top-panel settings, and close cleanly.
- Browse installed add-ons, enable/disable an add-on, review updates, and open plugin settings with NVDA.
