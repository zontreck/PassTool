import 'dart:convert';
import 'package:pass_tool/zhash.dart';

class CipherPasswordLegacy {
  List<String> blacklist;
  String rawText;
  int seed;
  int length;

  CipherPasswordLegacy({
    required this.blacklist,
    required this.rawText,
    required this.seed,
    this.length = 5,
  });

  String Manipulate() {
    List<int> result = utf8.encode(ZHash.ZHS(rawText, length));

    int oldSeed = seed;
    List<int> source = List<int>.from(result);

    List<int> pwd = List<int>.filled(length, 0);
    int P = 0;
    for (int X in source) {
      if (P >= length) P = 0;
      pwd[P] += X;
      P++;
    }

    source = List<int>.from(pwd);

    P = 0;
    // Slam the length to the desired length
    for (int X in List<int>.from(pwd)) {
      pwd[P] = (X ^ seed) + (X + seed);
      P++;
    }

    int MIN = 32;
    int MAX = 126;
    P = 0;
    List<int> used = [];

    for (int X in List<int>.from(pwd)) {
      bool found = false;
      int VAL = X;
      int tries = 0; // MAX TRIES = 255

      while (!found) {
        while (VAL > MAX) {
          VAL = VAL >> 2;
        }

        if (VAL < MAX &&
                VAL > MIN &&
                !used.contains(VAL) &&
                !blacklist.contains(String.fromCharCode(VAL)) ||
            tries > 255 && !blacklist.contains(String.fromCharCode(VAL))) {
          used.add(VAL);
          found = true;
          break;
        } else {
          if ((seed & 1) == 1) {
            VAL += VAL % 2;
          }
          if ((seed & 2) == 2) {
            VAL += VAL % 3;
          }
          if ((seed & 4) == 4) {
            VAL += VAL % 4;
          }
          if ((seed & 8) == 8) {
            VAL += 3;
          }
          if ((seed & 16) == 16) {
            VAL += 9;
          }
          if ((seed & 32) == 32) {
            VAL += seed;
          }
          if ((seed & 64) == 64) {
            VAL += VAL % 10;
          }
          if ((seed & 128) == 128) {
            VAL ~/= 2;
          }
          if ((seed & 256) == 256) {
            VAL ~/= 3;
          }
          //var ored = 1 | 2 | 4 | 8 | 16 | 32 | 64 | 128 | 256;
          //var anded = seed & ored;
          //var added = VAL + anded;
          // The below code has some inconsistent behavior.
          // TODO: Redo this as a v2 generator, keep the legacy behavior for now.
          VAL += (seed & 1 | 2 | 4 | 8 | 16 | 32 | 64 | 128 | 256);
          VAL += source[P];
          try {
            seed += (source[P] * P);
          } catch (e) {
            seed ~/= (source[P]);
          }
          tries++;
        }
      }

      pwd[P] = VAL;
      P++;
    }

    String ret = makePass(pwd);
    return ret;
  }

  String makePass(List<int> pwd) {
    return String.fromCharCodes(pwd);
  }
}
