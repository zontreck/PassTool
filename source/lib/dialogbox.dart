// ignore_for_file: non_constant_identifier_names, prefer_typing_uninitialized_variables, prefer_const_constructors

import 'package:flutter/material.dart';

class InputBox extends StatelessWidget {
  String hintText = "";
  Function(String) changed;
  Function() onSubmit;
  Function() onCancel;
  bool isDefault = false;
  bool showsCaseSensitiveWarning = false;
  bool isNumeric = false;
  String promptText = "";

  TextEditingController value = TextEditingController();

  InputBox(String defaultText,
      {super.key,
      this.hintText = "",
      required this.promptText,
      required this.changed,
      required this.onSubmit,
      required this.onCancel,
      required this.isDefault,
      this.showsCaseSensitiveWarning = false,
      this.isNumeric = false}) {
    if (isDefault) {
      value.text = "";
    } else
      value.text = defaultText;
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
        backgroundColor: Color.fromARGB(179, 0, 145, 125),
        icon: Icon(showsCaseSensitiveWarning ? Icons.warning : Icons.info),
        elevation: 8,
        actions: [
          ElevatedButton(
            onPressed: () {
              onSubmit();
              Navigator.of(context).pop();
            },
            child: Text("Submit"),
            style: ButtonStyle(
                backgroundColor: MaterialStateColor.resolveWith(
                    (states) => const Color.fromARGB(255, 0, 83, 3))),
          ),
          ElevatedButton(
              onPressed: () {
                onCancel();
                Navigator.of(context).pop();
              },
              child: Text("Cancel"),
              style: ButtonStyle(
                  backgroundColor: MaterialStateColor.resolveWith(
                      (states) => const Color.fromARGB(255, 109, 7, 0))))
        ],
        content: Container(
            height: 128,
            //decoration: BoxDecoration(
            //border: Border.all(style: BorderStyle.solid),
            //borderRadius: BorderRadius.all(Radius.circular(12))),
            child: Column(
              children: [
                if (showsCaseSensitiveWarning) Text("WARNING: Case Sensitive"),
                Text(promptText),
                TextField(
                  decoration: InputDecoration(
                      border: OutlineInputBorder(), hintText: hintText),
                  onChanged: changed,
                  controller: value,
                  keyboardType:
                      isNumeric ? TextInputType.number : TextInputType.text,
                ),
                Row(
                  children: [],
                )
              ],
            )));
  }
}
