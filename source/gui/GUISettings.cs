using System;
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
        public const int VERSION = 6;

        public EntryList<Word> OldBlacklist;
        public WordList Blacklist;
        public VInt32 LastLength;
        public VInt32 CurVer;
        public VInt32 LastSeed;

        public VBool Activated; // This is just a test for activation, so expiry won't be implemented.
        public Word ActivatedTo;
        public VByte ActivatedKeyType;
        


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
            ActivateV5();
            ActivateV6();
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

            key.Add(Blacklist);
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
            key.Add(LastSeed);


        }

        private void ActivateV5()
        {
            CurVer.setInt32(5);
            Activated = new VBool("activated", false);
            ActivatedTo = new Word("activated_to", "");

            key.Add(Activated);
            key.Add(ActivatedTo);
        }

        public void ActivateV6()
        {
            CurVer.setInt32(6);

            ActivatedKeyType = new VByte("activation_type", (byte)Licensing.KeyType.Unknown);

            key.Add(ActivatedKeyType);
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
                        OldBlacklist = key.getNamed("blacklist") as EntryList<Word>;

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

                        ActivateV5();
                        break;
                    }
                case 5:
                    {
                        LastLength = key.getNamed("len").Int32();
                        CurVer = key.getNamed("version").Int32();
                        Blacklist = key.getNamed("blacklist").WordList();
                        LastSeed = key.getNamed("last_seed").Int32();


                        saveLength = key.getNamed("save_len").Bool();
                        saveBlacklist = key.getNamed("save_blacklist").Bool();
                        saveSeed = key.getNamed("save_seed").Bool();

                        Activated = key.getNamed("activated").Bool();
                        ActivatedTo = key.getNamed("activated_to").Word();

                        ActivateV6();
                        break;

                    }
                case 6:
                    {
                        LastLength = key.getNamed("len").Int32();
                        CurVer = key.getNamed("version").Int32();
                        Blacklist = key.getNamed("blacklist").WordList();
                        LastSeed = key.getNamed("last_seed").Int32();


                        saveLength = key.getNamed("save_len").Bool();
                        saveBlacklist = key.getNamed("save_blacklist").Bool();
                        saveSeed = key.getNamed("save_seed").Bool();

                        Activated = key.getNamed("activated").Bool();
                        ActivatedTo = key.getNamed("activated_to").Word();
                        ActivatedKeyType = key.getNamed("activation_type").Byte();

                        break;
                    }
            }
        }
    }
}
