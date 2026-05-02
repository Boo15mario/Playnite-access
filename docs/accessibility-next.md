# Accessibility Follow-Up Work

This document tracks the next Desktop-mode accessibility slices after filter/search navigation.

## B. Game Details, Play, and Edit Actions

Goal: a screen-reader user can understand the selected game details and launch or edit the game without object navigation.

Scope:
- Add accessible names to icon-only game action buttons in details and grid views.
- Ensure game title, install state, source/platform, play status, links, and description are reachable in a logical order.
- Verify keyboard paths for play, install/uninstall, edit metadata, context menu, and details/sidebar toggles.
- Make launch failures and action results discoverable through named status text or compatible UI Automation events.

Validation:
- Select a game from the library with only the keyboard.
- Read core details with NVDA.
- Launch, open context actions, and open edit metadata without mouse routing or OCR.

## C. Settings and Add-ons Manager

Goal: a screen-reader user can configure Playnite and manage add-ons using standard keyboard navigation.

Scope:
- Review settings sections for unlabeled text boxes, combo boxes, list views, sliders, and icon-only buttons.
- Add `AutomationProperties.Name` or `AutomationProperties.LabeledBy` where visible labels are not exposed.
- Ensure add-on lists announce add-on name, type, installed/enabled state, update availability, and selected state.
- Check plugin settings host behavior so third-party WPF controls keep useful labels and tab order.

Validation:
- Open settings, change accessibility option, change theme/top-panel settings, and close cleanly.
- Browse installed add-ons, enable/disable an add-on, review updates, and open plugin settings with NVDA.
