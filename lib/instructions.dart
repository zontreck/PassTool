import 'dart:async';

import 'package:flutter/material.dart';
import 'package:libacflutter/Constants.dart';
import 'package:pass_tool/keyboard.dart';
import 'package:pass_tool/settings.dart';

class Instructions extends StatefulWidget {
  const Instructions({super.key});

  @override
  InstructionsState createState() => InstructionsState();
}

class InstructionsState extends State<Instructions> {
  Settings settings = Settings();

  bool firstBoot = true;

  InstructionsState();

  @override
  Future<void> didChangeDependencies() async {
    if (!settings.initialized) await settings.read();
  }

  @override
  void initState() {
    super.initState();

    WidgetsBinding.instance.addPostFrameCallback((timeStamp) {
      if (firstBoot) {
        if (!settings.isFirstBoot) {
          Navigator.of(context).pushNamed("/generator", arguments: settings);
        } else {
          settings.isFirstBoot = !settings.isFirstBoot;
          settings.write();
        }

        firstBoot = false;
      }
    });
  }

  Future<void> openBlacklist() async {
    var result = await Navigator.pushNamed(context, "/blacklist",
        arguments: BlacklistArguments(
            selected: settings.blacklist, settings: settings));
    settings.write();
  }

  @override
  Widget build(BuildContext context) {
    TextStyle A = TextStyle(fontSize: 18);
    TextStyle B =
        TextStyle(color: Color.fromARGB(255, 200, 100, 100), fontSize: 18);
    return Scaffold(
      appBar: AppBar(
        title: Text("Password Tool - Welcome"),
        backgroundColor: LibACFlutterConstants.TITLEBAR_COLOR,
      ),
      body: Padding(
        padding: EdgeInsets.all(16),
        child: SingleChildScrollView(
            child: Column(
          children: [
            Text(
              "Welcome to Password Tool!",
              style: A,
            ),
            Text(
                "This program does not save any of the passwords it generates. You must remember the seed, and source text. It is also worth noting that the blacklist will influence the password and can drastically change the outcome.",
                style: B),
            SizedBox(
              height: 16,
            ),
            Text(
                "To create a password, on the generator screen, tap or click the Cipher Text option, and input your desired value. For instance \"myname @ example.com\".",
                style: A),
            SizedBox(
              height: 26,
            ),
            Text(
                "The seed value will also change the output, so pick a number you will remember. For instance, 20230123.",
                style: A),
            SizedBox(
              height: 12,
            ),
            Text(
                "The same values will always output the same password. You must remember the parameters that created the password. For the most security, do not store or write down the parameters!",
                style: B),
            Text(
                "The above parameters with the default blacklist and length of 5, will always output \" 3*(fM \" as the password.",
                style: B)
          ],
        )),
      ),
      drawer: Drawer(
        backgroundColor: Colors.blueAccent,
        child: Column(
          children: [
            DrawerHeader(
              child: Column(
                children: [
                  Icon(Icons.key, size: 38),
                  Text("Created by Tara Piccari"),
                  Text("Copyright 2023-2025"),
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
                    Navigator.pushNamed(context, "/generator",
                        arguments: settings);
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
    );
  }
}
