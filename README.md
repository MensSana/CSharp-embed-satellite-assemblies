# CSharp-embed-satellite-assemblies
Embedding satellite assembly into DLL

### All the magic happens in Program.cs and the Post Build Event, which calls ManageLanguage.cmd.

1. Make sure ManageLanguage.cmd is saved with encoding "OEM United States - Codepage 437"
1. Create a 2-letter-for-language folder at Project root for each language you wish to embed
1. Add Post Build Event line for each language
   - call "$(ProjectDir)ManageLanguage.cmd" &lt;language&gt; "$(ProjectDir)" "$(TargetDir)" "$(TargetName)"
   - &lt;language&gt; is 2 letter code (en, fr, de, es, ru, ja, ...)
1. Build
1. Add the copied DLL located in language folder at root of project to project
   - (Search for * to make it appear in file explorer)
   - Change Build Action for the added DLL to Embedded Resource
1. Rebuild (Note: You always better build twice to make sure new translations get embedded)
