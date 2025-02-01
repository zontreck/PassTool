import 'dart:math';

import 'package:flutter/material.dart';
import 'package:libac_dart/nbt/NbtIo.dart';
import 'package:libac_dart/nbt/NbtUtils.dart';
import 'package:libac_dart/nbt/impl/CompoundTag.dart';
import 'package:libac_dart/nbt/impl/IntTag.dart';
import 'package:libac_dart/nbt/impl/ListTag.dart';
import 'package:libac_dart/nbt/impl/StringTag.dart';
import 'package:libacflutter/Constants.dart';

class Settings {
  bool saveSeed = false;
  bool saveLength = true;
  bool saveBlacklist = true;
  List<String> blacklist = [",", ".", "'", "\"", "/", "\\", "|", "#", "&"];
  int lastSeed = 1;
  int lastLength = 5;
  bool isDark = true;
  bool isFirstBoot = true;

  bool initialized = false;

  Future<void> read() async {
    CompoundTag tag = await NbtIo.read("PassTool.nbt");

    saveSeed = tag.containsKey("saveSeed")
        ? NbtUtils.readBoolean(tag, "saveSeed")
        : false;
    saveLength = tag.containsKey("saveLength")
        ? NbtUtils.readBoolean(tag, "saveLength")
        : false;
    saveBlacklist = tag.containsKey("saveBlacklist")
        ? NbtUtils.readBoolean(tag, "saveBlacklist")
        : true;

    lastSeed = tag.containsKey("seed")
        ? tag.get("seed")!.asInt()
        : ((Random().nextInt(pow(2, 4).toInt() - 1) + 1)).toInt();

    lastLength = tag.containsKey("length") ? tag.get("length")!.asInt() : 5;

    if (tag.containsKey("blacklist")) {
      blacklist = [];
      for (var str in (tag.get("blacklist")! as ListTag).value) {
        blacklist.add(str.asString());
      }
    } else {
      blacklist = [",", ".", "'", "\"", "/", "\\", "|", "#", "&"];
    }

    isDark = tag.containsKey("dark") ? NbtUtils.readBoolean(tag, "dark") : true;

    if (lastLength <= 0 || lastLength >= 41) lastLength = 5;

    isFirstBoot = tag.containsKey("onboard")
        ? NbtUtils.readBoolean(tag, "onboard")
        : true;

    initialized = true;
  }

  void write() {
    CompoundTag ct = CompoundTag();

    NbtUtils.writeBoolean(ct, "saveSeed", saveSeed);
    NbtUtils.writeBoolean(ct, "saveLength", saveLength);
    NbtUtils.writeBoolean(ct, "saveBlacklist", saveBlacklist);

    if (saveSeed) ct.put("seed", IntTag.valueOf(lastSeed));

    if (saveLength) ct.put("length", IntTag.valueOf(lastLength));

    if (saveBlacklist) {
      ListTag lst = ListTag();
      for (var entry in blacklist) {
        lst.add(StringTag.valueOf(entry));
      }

      ct.put("blacklist", lst);
    }

    NbtUtils.writeBoolean(ct, "dark", isDark);
    NbtUtils.writeBoolean(ct, "onboard", isFirstBoot);

    NbtIo.write("PassTool.nbt", ct);
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
      appBar: AppBar(
        title: const Text("Settings"),
        backgroundColor: LibACFlutterConstants.TITLEBAR_COLOR,
      ),
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
                    } else {
                      settings.saveBlacklist = false;
                    }

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
                      } else {
                        settings.saveLength = false;
                      }

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
                      } else {
                        settings.saveSeed = false;
                      }

                      settings.write();
                    });
                  },
                  title: Text("Save Seed"))
            ],
          )),
    );
  }
}
