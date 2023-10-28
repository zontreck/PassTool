import 'dart:math';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:pass_tool/cipherpasslegacy.dart';
import 'package:pass_tool/dialogbox.dart';
import 'package:pass_tool/keyboard.dart';
import 'package:pass_tool/settings.dart';

class Generator extends StatefulWidget {
  const Generator({super.key});

  @override
  GeneratorState createState() => GeneratorState();
}

class GeneratorState extends State<Generator> {
  bool isDarkMode = false;
  bool firstLoad = false;
  bool isDefaultCipher = true;
  String cipherText = 'Tap/Click here to set passphrase';
  int seed =
      Random().nextInt(pow(2, 4).toInt() - 1) + 1; // Generate a random seed
  int length = 5;
  TextEditingController seedController = TextEditingController();
  TextEditingController lengthController = TextEditingController();
  TextEditingController blacklistController = TextEditingController();
  List<String> blacklistedCharacters = [];
  String generatedPassword = '';
  Settings settings = Settings();

  void toggleTheme() {
    setState(() {
      isDarkMode = !isDarkMode;

      settings.isDark = isDarkMode;
      settings.write();
    });
  }

  void generatePassword() {
    // Implement your password generation logic here
    // Assign the generated password to the 'generatedPassword' variable
    setState(() {
      generatedPassword = CipherPasswordLegacy(
              blacklist: blacklistedCharacters,
              rawText: cipherText,
              seed: seed,
              length: length)
          .Manipulate();
    });
  }

  Future<void> openBlacklist() async {
    var result = await Navigator.pushNamed(context, "/blacklist",
        arguments: BlacklistArguments(
            selected: blacklistedCharacters, settings: settings));
    settings.write();
  }

  void copyToClipboard() {
    Clipboard.setData(ClipboardData(text: generatedPassword));
    ScaffoldMessenger.of(context).showSnackBar(SnackBar(
      content: Text('Password copied to clipboard'),
    ));
  }

  @override
  Widget build(BuildContext context) {
    if (!firstLoad) {
      var args = ModalRoute.of(context)!.settings.arguments;
      firstLoad = true;

      settings = args as Settings;

      if (settings.saveSeed) {
        seed = settings.lastSeed;
        seedController.text = seed.toString();
      } else {
        seedController.text = seed.toString();
      }

      if (settings.saveLength) {
        length = settings.lastLength;
        lengthController.text = length.toString();
      } else {
        lengthController.text = length.toString();
      }

      if (settings.saveBlacklist) {
        blacklistedCharacters = settings.blacklist;
      } else
        settings.blacklist = blacklistedCharacters;

      isDarkMode = settings.isDark;
    }
    return Scaffold(
      appBar: AppBar(
        title: Text('Password Tool'),
        actions: [
          IconButton(
              icon: Icon(Icons.settings),
              onPressed: () {
                Navigator.pushNamed(context, "/settings", arguments: settings);
              }),
        ],
      ),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            children: <Widget>[
              ListTile(
                  title: Text("Cipher Text (Case Sensitive)"),
                  subtitle: Text(cipherText),
                  onTap: () {
                    var dialog = InputBox(
                      cipherText,
                      changed: (text) {
                        setState(() {
                          cipherText = text;
                          isDefaultCipher = false;
                        });
                      },
                      hintText: "Passphrase",
                      onCancel: () {},
                      onSubmit: () {},
                      isDefault: isDefaultCipher,
                      showsCaseSensitiveWarning: true,
                      promptText: "What is your pass phrase?",
                    );

                    showDialog(
                        context: context,
                        builder: (context) {
                          return dialog;
                        });
                  }),
              SizedBox(height: 16),
              Row(
                children: <Widget>[
                  Text('Seed:'),
                  SizedBox(width: 16),
                  Flexible(
                    child: Slider(
                      value: seed.toDouble(),
                      onChanged: (newValue) {
                        setState(() {
                          seed = newValue.toInt();
                          seedController.text = newValue.toString();

                          settings.lastSeed = newValue.toInt();
                          settings.write();
                        });
                      },
                      min: 1,
                      max: pow(2, 28).toInt() -
                          1, // Set maximum to int32 maximum
                    ),
                  ),
                  SizedBox(width: 16),
                  Flexible(
                      child: ListTile(
                          title: Text(seedController.text),
                          onTap: () {
                            InputBox prompt = InputBox(
                              promptText:
                                  "What would you like the seed to be?\nThis helps the generator determine what the password should be.",
                              seedController.text,
                              changed: (v) {
                                seedController.text = v;
                              },
                              onSubmit: () {
                                setState(() {
                                  seed = int.tryParse(seedController.text) ?? 1;
                                  settings.lastSeed = seed;
                                  settings.write();
                                });
                              },
                              onCancel: () {
                                seedController.text = seed.toString();
                              },
                              isDefault: false,
                              hintText: "Numeric Seed Value",
                              isNumeric: true,
                            );

                            showDialog(
                                context: context,
                                builder: (x) {
                                  return prompt;
                                });
                          })),
                ],
              ),
              Row(
                children: <Widget>[
                  Text('Length:'),
                  SizedBox(width: 16),
                  Flexible(
                    child: Slider(
                      value: length.toDouble(),
                      onChanged: (newValue) {
                        setState(() {
                          length = newValue.toInt();
                          lengthController.text = newValue.toString();

                          settings.lastLength = length;
                          settings.write();
                        });
                      },
                      min: 1,
                      max: 40,
                    ),
                  ),
                  SizedBox(width: 16),
                  Flexible(
                      child: ListTile(
                          title: Text(lengthController.text),
                          onTap: () {
                            InputBox prompt = InputBox(
                              lengthController.text,
                              changed: (V) {
                                lengthController.text = V;
                              },
                              onSubmit: () {
                                setState(() {
                                  length =
                                      int.tryParse(lengthController.text) ?? 1;
                                  settings.lastLength = length;
                                  settings.write();
                                });
                              },
                              onCancel: () {
                                lengthController.text = length.toString();
                              },
                              isDefault: false,
                              hintText: "Length Of Password",
                              isNumeric: true,
                              showsCaseSensitiveWarning: false,
                              promptText:
                                  "What would you like the length of the password to be?",
                            );

                            showDialog(
                                context: context,
                                builder: (X) {
                                  return prompt;
                                });
                          })
                      /*
                    child: TextField(
                      controller: lengthController,
                      onChanged: (text) {
                        setState(() {
                          length = int.tryParse(text) ?? 5;

                          settings.lastLength = length;
                          settings.write();
                        });
                      },
                    ),*/
                      ),
                ],
              ),
              ListTile(
                  leading: Icon(Icons.block),
                  title: Text("Blacklisted Characters"),
                  subtitle:
                      Text("Click here to edit or view the current blacklist"),
                  onTap: () {
                    openBlacklist();
                  }),
              SizedBox(height: 32),
              ElevatedButton(
                onPressed: generatePassword,
                child: Text('Generate Password'),
              ),
              SizedBox(height: 16),
              Text('Password Output:'),
              Text(generatedPassword),
              ElevatedButton(
                onPressed: () {
                  if (generatedPassword.isNotEmpty) {
                    copyToClipboard();
                  }
                },
                child: Text('Copy to Clipboard'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
