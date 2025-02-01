// ignore_for_file: prefer_const_literals_to_create_immutables, prefer_const_constructors
import 'package:flutter/material.dart';
import 'package:libacflutter/Constants.dart';

import 'package:pass_tool/settings.dart';

class BlacklistView extends StatefulWidget {
  const BlacklistView({super.key});

  @override
  _CustomKeyboardState createState() => _CustomKeyboardState();
}

class BlacklistArguments {
  List<String> selected;
  Settings settings;

  BlacklistArguments({required this.selected, required this.settings});
}

class BlacklistReturnValue {
  List<String> selected;
  BlacklistReturnValue({required this.selected});
}

class _CustomKeyboardState extends State<BlacklistView> {
  List<String> selectedKeys = [];

  List<String> keyboardKeys = [
    "!",
    "@",
    "`",
    "~",
    "#",
    "\$",
    "%",
    "^",
    "&",
    "*",
    "(",
    ")",
    "-",
    "_",
    "=",
    "+",
    ",",
    "<",
    ".",
    ">",
    "/",
    "?",
    ";",
    ":",
    "'",
    "\"",
    "{",
    "}",
    "[",
    "]",
    "|",
    "\\"
  ];

  bool isKeySelected(String key) {
    return selectedKeys.contains(key);
  }

  void toggleKeySelection(String key) {
    setState(() {
      if (isKeySelected(key)) {
        selectedKeys.remove(key);
      } else {
        selectedKeys.add(key);
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    final args = ModalRoute.of(context)?.settings.arguments;
    if (args != null) {
      var arg = args as BlacklistArguments;
      selectedKeys = arg.selected;
    }

    // Determine the number of columns based on the screen size
    int columnsCount = 4; // Default for mobile
    if (MediaQuery.of(context).size.width >= 800) {
      columnsCount = 8; // Use 8 columns for desktop or larger screens
    }

    return Scaffold(
        appBar: AppBar(
          title: Text("Blacklist"),
          backgroundColor: LibACFlutterConstants.TITLEBAR_COLOR,
        ),
        body: GridView.builder(
          gridDelegate: SliverGridDelegateWithMaxCrossAxisExtent(
            maxCrossAxisExtent: 120, // Adjust as needed
            crossAxisSpacing: 8, // Adjust as needed
            mainAxisSpacing: 8, // Adjust as needed
            childAspectRatio: 1.5, // Adjust as needed
          ),
          itemCount: keyboardKeys.length,
          itemBuilder: (context, index) {
            String key = keyboardKeys[index];
            return Padding(
              padding: EdgeInsets.all(8.0),
              child: ElevatedButton(
                  onPressed: () {
                    toggleKeySelection(key);
                  },
                  style: ElevatedButton.styleFrom(
                      backgroundColor: isKeySelected(key)
                          ? const Color.fromARGB(255, 153, 10, 0)
                          : Color.fromARGB(255, 0, 179, 192),
                      textStyle: TextStyle(fontSize: 32),
                      foregroundColor: Color.fromARGB(255, 31, 0, 88)),
                  child: Text(key)),
            );
          },
        ));
  }
}
