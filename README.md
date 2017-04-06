## QuickCopy
A very simple password management tool. It aims to simplify the task of copy-pasting frequently used text, like usernames and passwords. A Windows-only tool, it’s code purely in C#, and makes use of the wonderfully portable SQLite to store entries in the backend.

The interface includes 2 components (basically 3; one is hidden) — system tray icon and "add content" dialog. All content added through the dialog gets added as a menu item in the system tray icon’s context menu (the one you see on right-clicking the icon). To copy a content from the menu to the clipboard, all you need to do is just click on its entry in the menu and it's done!

Some features:
* **Store content** – frequently used text, like usernames.
* **Store passwords** – these are masked by content tags, which are then shown in the context menu (in red color).
* **Hotkeys** – the top 3 entries in the context menu can be quickly copied to the clipboard using the key combinations of CTRL+F1, CTRL+F2 and CTRL+F3.

For a password, its respective content tag acts as a mask to hide it under its name. Say you’re adding your Gmail password @ILuvKatz!! in the dialog, and set its content tag as Gmail Password, the password's entry will appear in the menu in red color with the name Gmail Password. When you click on Gmail Password, your actual password will be copied to the clipboard.

There is no easy provision of modifying existing content entries. But I've provided a QueryEditor (invoked by pressing CTRL+Q in the "Add Content" dialog), where you can change the content entries by issuing your regular SQL queries. For example:

```sql
UPDATE content SET content='@IHateKatz!!' WHERE content_tag='Gmail Password'
```