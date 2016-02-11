# Game We Still Haven't Named
### By Executable Games

## About

An RPG game about a group of misfit objects that just want to escape the attic.

## Version Control

**PSA**: If you haven't, go into your Unity Editor Project Settings (Edit > Project Settings > Editor) and make
sure that your Version Control mode is set to "Visible Meta Files."

We only need to track `Assets` and `ProjectSettings` for this, so please avoid committing other files where possible.
The current `.gitignore` file should be enough to keep any auto-generated folders out of the repo, so this should
be easy to do.

## Guidelines

* Do all your work in branches
* Add C# XML Docs to your Classes
  * Presumably you're using visual studio, so just type `///` above a method and it will generate a doc template
* When you are done doing work in a branch, submit a Pull Request and await code review
* Assign yourself to an issue only once you have begun to work on it
* If you create a new file, in addition to creating a C# XML Doc at the top (above the `class`), make sure you
  add a line for `Author: <Your Name> (GitHub: <Your Username>)` so that we know who is responsible originally
  for that code. Add another line below that for the date.
  * **If you modify a class**, then at the top of the file below the created-at date put a comment of the form
    `/// Modified: <M/D/YYYY> <Your Name> (GitHub: <Your Username>)`. Someone can then use Git to find out what you
    changed by searching through the commit history for that date.
  * It's fine if there are a bunch of `Modified` comments, put yours at the top (so that the most recent modification
    is always the first one you see).

## Questions

If you need help with something, esp. Git-related, you can ping me (type `@skorlir` anywhere in GitHub and 
I'll get a notification) or use the facebook group or hmu I'm probably in The Garage working on stuff.

