import 'dart:math';

import 'package:flutter/material.dart';
import 'package:hive/hive.dart';

class Settings {
  bool saveSeed = false;
  bool saveLength = true;
  bool saveBlacklist = true;
  List<String> blacklist = [",", ".", "'", "\"", "/", "\\", "|", "#", "&"];
  int lastSeed = 1;
  int lastLength = 5;
  bool isDark = true;

  void read() {
    var box = Hive.box("PassTool");

    saveSeed = box.get("saveSeed", defaultValue: false);
    saveLength = box.get("saveLength", defaultValue: false);
    saveBlacklist = box.get("saveBlacklist", defaultValue: true);

    lastSeed = box.get("seed",
        defaultValue: ((Random().nextInt(pow(2, 4).toInt() - 1) + 1)).toInt());
    lastLength = box.get("length", defaultValue: 5);
    blacklist = box.get("blacklist",
        defaultValue: [",", ".", "'", "\"", "/", "\\", "|", "#", "&"]);
    isDark = box.get("dark", defaultValue: true);

    if (lastLength <= 0 || lastLength >= 41) lastLength = 5;
  }

  void write() {
    var box = Hive.box("PassTool");

    box.put("saveSeed", saveSeed);
    box.put("saveLength", saveLength);
    box.put("saveBlacklist", saveBlacklist);

    if (saveSeed)
      box.put("seed", lastSeed);
    else
      box.delete("seed");

    if (saveLength)
      box.put("length", lastLength);
    else
      box.delete(("length"));

    if (saveBlacklist)
      box.put("blacklist", blacklist);
    else
      box.delete("blacklist");

    box.put("dark", isDark);
  }
}

class SettingsPage extends StatefulWidget {
  const SettingsPage({super.key});

  @override
  State<StatefulWidget> createState() {
    return SettingsPageState();
  }
}

class SettingsPageState extends State<SettingsPage> {
  Settings settings = Settings();

  @override
  Widget build(BuildContext context) {
    var arg = ModalRoute.of(context)?.settings.arguments;
    if (arg != null) {
      settings = arg as Settings;
    }
    return Scaffold(
      appBar: AppBar(title: const Text("Settings")),
      body: Padding(
          padding: EdgeInsets.all(16),
          child: Column(
            children: [
              CheckboxListTile(
                value: settings.saveBlacklist,
                onChanged: (value) {
                  setState(() {
                    if (value != null) {
                      settings.saveBlacklist = value;
                    } else
                      settings.saveBlacklist = false;

                    settings.write();
                  });
                },
                title: Text("Save Blacklist"),
              ),
              CheckboxListTile(
                  value: settings.saveLength,
                  onChanged: (value) {
                    setState(() {
                      if (value != null) {
                        settings.saveLength = value;
                      } else
                        settings.saveLength = false;

                      settings.write();
                    });
                  },
                  title: Text("Save Length")),
              CheckboxListTile(
                  value: settings.saveSeed,
                  onChanged: (value) {
                    setState(() {
                      if (value != null) {
                        settings.saveSeed = value;
                      } else
                        settings.saveSeed = false;

                      settings.write();
                    });
                  },
                  title: Text("Save Seed"))
            ],
          )),
    );
  }
}
