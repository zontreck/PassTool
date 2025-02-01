import 'dart:convert';
import 'dart:typed_data';
import 'package:crypto/crypto.dart';

class ZHash {
  String _key;
  final String _template;

  ZHash(this._key, this._template);

  void reset() {
    _key = _template;
  }

  @override
  String toString() {
    return _key;
  }

  void newKey() {
    _key = '${'0' * 10}-${'0' * 4}-${'0' * 6}-${'0' * 8}';
  }

  void newSerial() {
    _key =
        '${'0' * 10}-${'0' * 6}-${'0' * 4}-${'0' * 4}-${'0' * 2}-${'0' * 4}-${'0' * 8}';
  }

  void calculateKey(String K) {
    String valid =
        "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ=.+/\\][{}';:?><,_-)(*&^%\$#@!`~|";
    while (valid.length < K.length) {
      valid += valid;
    }
    List<int> tmp = _key.runes.toList();

    for (int i = 0; i < _key.length; i++) {
      int V = _key.runes.elementAt(i);
      if (String.fromCharCode(V) != '-') {
        for (int ii = 0;
            ii < ((K.length > _key.length) ? _key.length : K.length);
            ii++) {
          Digest md5Data = md5.convert(Uint8List.fromList(utf8.encode(
              K + i.toString() + valid[i].toString() + valid[ii].toString())));
          String hash = md5Data.toString();

          tmp[i] = hash.runes.elementAt((i > 31 ? 1 : i));
        }
      }
    }
    _key = String.fromCharCodes(tmp).toUpperCase();
  }

  static Uint8List hashToBytes(String key) {
    List<int> bytes = <int>[];
    for (int i = 0; i < key.length; i += 2) {
      bytes.add(int.parse(key.substring(i, i + 2), radix: 16));
    }
    return Uint8List.fromList(bytes);
  }

  static ZHash bytesToHash(Uint8List key) {
    String keyStr = '';
    for (int b in key) {
      keyStr += b.toRadixString(16).padLeft(2, '0');
    }
    return ZHash(keyStr, keyStr);
  }

  static String bytesToHashStr(Uint8List key) {
    return bytesToHash(key)._key;
  }

  static String ZHX(String toHash) {
    ZHash tmp = ZHash('0000000000-0000-000000-00000000', '');
    tmp.newKey();
    tmp.calculateKey(toHash);
    return tmp._key;
  }

  static String ZHS(String toHash, int len) {
    ZHash tmp = bytesToHash(Uint8List(len));
    tmp.calculateKey(toHash);
    return tmp._key;
  }

  static String ZSR(String toSerialize) {
    ZHash tmp = ZHash('0000000000-000000-0000-0000-00-0000-00000000', '');
    tmp.newSerial();
    tmp.calculateKey(toSerialize);
    return tmp._key;
  }
}
