// ignore_for_file: prefer_const_constructors, prefer_const_literals_to_create_immutables

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:hive_flutter/adapters.dart';
import 'package:pass_tool/cipherpasslegacy.dart';
import 'dart:math';
import 'settings.dart';
import 'dialogbox.dart';
import 'keyboard.dart';
import 'zhash.dart';

Future<void> main() async {
  await Hive.initFlutter();
  await Hive.openBox("PassTool");
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        theme: ThemeData.light(), // Default theme is light mode
        darkTheme: ThemeData.dark(),
        home: MyHomePage(),
        routes: {
          '/settings': (context) => SettingsPage(),
          "/legacy": (context) => MyHomePage(),
          "/blacklist": (context) => BlacklistView()
        });
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key});

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  bool isDarkMode = false;
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

  void copyToClipboard() {
    Clipboard.setData(ClipboardData(text: generatedPassword));
    ScaffoldMessenger.of(context).showSnackBar(SnackBar(
      content: Text('Password copied to clipboard'),
    ));
  }

  Future<void> openBlacklist() async {
    var result = await Navigator.pushNamed(context, "/blacklist",
        arguments: BlacklistArguments(selected: blacklistedCharacters));
    settings.write();
  }

  @override
  Widget build(BuildContext context) {
    settings.read();

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
      drawer: Drawer(
        backgroundColor: Colors.blueAccent,
        child: SingleChildScrollView(
          child: Column(
            children: [
              DrawerHeader(
                child: Column(
                  children: [
                    Icon(Icons.key, size: 48),
                    Text("Created by Tara Piccari"),
                    Text("Copyright 2023"),
                    Text("https://github.com/zontreck/PassTool"),
                  ],
                ),
              ),
              Column(
                children: [
                  ListTile(
                    leading: Icon(Icons.dangerous),
                    title: Text("G E N E R A T O R"),
                    onTap: () {
                      Navigator.pushNamed(context, "/legacy");
                    },
                  ),
                  ListTile(
                    leading: Icon(Icons.settings),
                    title: Text("S E T T I N G S"),
                    onTap: () {
                      Navigator.pushNamed(context, "/settings",
                          arguments: settings);
                    },
                  ),
                  ListTile(
                    leading: Icon(Icons.block),
                    title: Text("B L A C K L I S T"),
                    onTap: () {
                      openBlacklist();
                    },
                  ),
                ],
              ),
            ],
          ),
        ),
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
                      max: pow(2, 18).toInt() -
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
