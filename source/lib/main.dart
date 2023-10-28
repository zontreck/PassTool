// ignore_for_file: prefer_const_constructors, prefer_const_literals_to_create_immutables

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:hive_flutter/adapters.dart';
import 'package:pass_tool/cipherpasslegacy.dart';
import 'package:pass_tool/generator.dart';
import 'package:pass_tool/instructions.dart';
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
  MyApp({super.key}) {}

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        theme: ThemeData.light(), // Default theme is light mode
        darkTheme: ThemeData.dark(),
        home: Instructions(),
        routes: {
          '/settings': (context) => SettingsPage(),
          "/generator": (context) => Generator(),
          "/blacklist": (context) => BlacklistView()
        });
  }
}
