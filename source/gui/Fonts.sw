using System;
using System.IO;
using System.Collections.Generic;

struct Fonts
{
	public string FontName;
	public string FamilyName;
}
List<Fonts> fonts = new();

fonts.Add(new(){
	FontName = "Cards.ttf",
	FamilyName = "Card Characters"
});
fonts.Add(new(){
	FontName = "Inkfree.ttf",
	FamilyName = "Ink Free"
});


Console.WriteLine("{\n"+
"\t\"namespace\": \"PassTool.GUI\",\n" +
"\t\"data\": {\n" +
"\t\t\"EmbeddedFonts\": {");

for(int i=0;i<fonts.Count;i++)
{
	Fonts F = fonts[i];
	string font = F.FontName;
	string fontFamily = F.FamilyName;
	bool hasNext = (i+1<fonts.Count);
	Console.Write("\t\t\t\"" + font.Replace(".", "_") + "\": {\n");
	Console.Write("\t\t\t\t\"FamilyName\": \"" + fontFamily + "\",\n");
	Console.Write("\t\t\t\t\"Data\": \"" + System.Convert.ToBase64String(File.ReadAllBytes(font)) + "\"\n");
	
	
	Console.Write("\t\t\t}");

	if(hasNext) Console.Write(",\n");
	else Console.Write("\n");
}

Console.WriteLine(
"\t\t}\n" +
"\t}\n" +
"}"

);