// ignore_for_file: prefer_const_constructors, prefer_const_literals_to_create_immutables

import 'package:flutter/material.dart';
import 'package:pass_tool/generator.dart';
import 'package:pass_tool/instructions.dart';
import 'settings.dart';
import 'keyboard.dart';

Future<void> main() async {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

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
