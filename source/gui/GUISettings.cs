﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.CS.Registry;

namespace PassTool.GUI
{
    public class GUISettings
    {
        public const string KEY = "root/gui";


        private Key MyEntry;

        public GUISettingsCodec codec;

        private GUISettings()
        {

        }
        public static void SettingsLoad(Key root)
        {
            Entry x = root.getAtPath(KEY);
            if(x == null)
            {
                var settings = new Key("gui", null);

                root.placeAtPath(KEY.Substring(0, KEY.LastIndexOf("/")), settings);
            }

            x = root.getAtPath(KEY);
            Instance = new GUISettings();
            Instance.MyEntry = x.Key();
            Instance.codec = new GUISettingsCodec(Instance.MyEntry);
        }


        public static GUISettings Instance { get; private set; }
    }

    public class GUISettingsCodec
    {
        public const int VERSION = 4;

        public EntryList<Word> OldBlacklist;
        public WordList Blacklist;
        public VInt32 LastLength;
        public VInt32 CurVer;
        public VInt32 LastSeed;


        public VBool saveLength;
        public VBool saveSeed;
        public VBool saveBlacklist;

        public bool New = true;

        private Key key;
        public GUISettingsCodec(Key key)
        {
            this.key = key;

            if(!key.HasNamedKey("version"))
            {
                Initialize();
            }else
            {
                New = false;
                VInt32 ver = key.getNamed("version").Int32();

                Load(ver.Value);
            }
        }

        private void Initialize()
        {
            ActivateV1();
            ActivateV2();
            ActivateV3();
            ActivateV4();
        }

        private void ActivateV1()
        {
            LastLength = new VInt32("len", 5);
            CurVer = new VInt32("version", 1);

            key.Add(LastLength);
            key.Add(CurVer);
        }

        private void ActivateV2()
        {
            OldBlacklist = new EntryList<Word>("blacklist");
            CurVer.setInt32(2);

            key.Add(OldBlacklist);
        }

        private void ActivateV3()
        {
            key.Remove(OldBlacklist);
            Blacklist = new WordList("blacklist");
            CurVer.setInt32(3);
        }

        private void ActivateV4()
        {
            saveLength = new VBool("save_len", true);
            saveBlacklist = new VBool("save_blacklist", true);
            saveSeed = new VBool("save_seed", false);
            LastSeed = new VInt32("last_seed", new Random().Next(0, 0xFFFF));

            CurVer.setInt32(4);

            key.Add(saveSeed);
            key.Add(saveLength);
            key.Add(saveBlacklist);


        }

        private void Load(int ver)
        {
            switch(ver)
            {
                case 1:
                    {
                        LastLength = key.getNamed("len").Int32();
                        CurVer = key.getNamed("version").Int32();

                        ActivateV2();
                        break;
                    }
                case 2:
                    {
                        LastLength = key.getNamed("len").Int32();
                        CurVer = key.getNamed("version").Int32();
                        OldBlacklist = key.getNamed("blacklist").Array<Word>();

                        ActivateV3();
                        break;
                    }
                case 3:
                    {
                        LastLength = key.getNamed("len").Int32();
                        CurVer = key.getNamed("version").Int32();
                        Blacklist = key.getNamed("blacklist").WordList();

                        ActivateV4();
                        break;

                    }
                case 4:
                    {
                        LastLength = key.getNamed("len").Int32();
                        CurVer = key.getNamed("version").Int32();
                        Blacklist = key.getNamed("blacklist").WordList();
                        LastSeed = key.getNamed("last_seed").Int32();


                        saveLength = key.getNamed("save_len").Bool();
                        saveBlacklist = key.getNamed("save_blacklist").Bool();
                        saveSeed = key.getNamed("save_seed").Bool();

                        break;
                    }
            }
        }
    }
}
