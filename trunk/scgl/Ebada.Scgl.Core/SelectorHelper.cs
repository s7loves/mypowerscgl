using System;
using System.Collections.Generic;
using System.Text;
using Ebada.Scgl.Model;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.IO;
using Ebada.Client;

namespace Ebada.Scgl.Core {
    /// <summary>
    /// 选择器助手
    /// </summary>
    public class SelectorHelper {
    private static System.Collections.Hashtable htqp;
    //private static System.Collections.Hashtable htsm;
    #region 确认输入文件路径的文件夹存在
    public static void EnableFilePathExit(string fileFullPath)
    {
        System.IO.DirectoryInfo Dir = new DirectoryInfo(fileFullPath);
        if (Directory.Exists(Dir.FullName) == false)//如果不存在就创建file文件夹
        {
            Directory.CreateDirectory(Dir.FullName);
        }
        DirectoryInfo topDir = Directory.GetParent(Dir.FullName);

        if (topDir.FullName != Dir.Root.FullName)
        {
            EnableFilePathExit(topDir.FullName);
        }
    }
    #endregion
    #region 汉字的区位对应表数组
    /*
        private static int[] pyvalue = new int[]{-20319,-20317,-20304,-20295,-20292,-20283,
        -20265,-20257,-20242,-20230,-20051,
        -20036,-20032,-20026, -20002,-19990,
        -19986,-19982,-19976,-19805,-19784,
        -19775,-19774,-19763,-19756,-19751,
        -19746,-19741,-19739,-19728, -19725,
        -19715,-19540,-19531,-19525,-19515,
        -19500,-19484,-19479,-19467,-19289,
        -19288,-19281,-19275,-19270,-19263, 
        -19261,-19249,-19243,-19242,-19238,
        -19235,-19227,-19224,-19218,-19212,
        -19038,-19023,-19018,-19006,-19003,
        -18996, -18977,-18961,-18952,-18783,
        -18774,-18773,-18763,-18756,-18741,
        -18735,-18731,-18722,-18710,-18697,
        -18696,-18526, -18518,-18501,-18490,
        -18478,-18463,-18448,-18447,-18446,
        -18239,-18237,-18231,-18220,-18211,
        -18201,-18184,-18183, -18181,-18012,
        -17997,-17988,-17970,-17964,-17961,
        -17950,-17947,-17931,-17928,-17922,
        -17759,-17752,-17733,-17730, -17721,
        -17703,-17701,-17697,-17692,-17683,
        -17676,-17496,-17487,-17482,-17468,
        -17454,-17433,-17427,-17417,-17202, 
        -17185,-16983,-16970,-16942,-16915,
        -16733,-16708,-16706,-16689,-16664,
        -16657,-16647,-16474,-16470,-16465,
        -16459, -16452,-16448,-16433,-16429,
        -16427,-16423,-16419,-16412,-16407,
        -16403,-16401,-16393,-16220,-16216,
        -16212,-16205, -16202,-16187,-16180,
        -16171,-16169,-16158,-16155,-15959,
        -15958,-15944,-15933,-15920,-15915,
        -15903,-15889,-15878, -15707,-15701,
        -15681,-15667,-15661,-15659,-15652,
        -15640,-15631,-15625,-15454,-15448,
        -15436,-15435,-15419,-15416, -15408,
        -15394,-15385,-15377,-15375,-15369,
        -15363,-15362,-15183,-15180,-15165,
        -15158,-15153,-15150,-15149,-15144, 
        -15143,-15141,-15140,-15139,-15128,
        -15121,-15119,-15117,-15110,-15109,
        -14941,-14937,-14933,-14930,-14929,
        -14928, -14926,-14922,-14921,-14914,
        -14908,-14902,-14894,-14889,-14882,
        -14873,-14871,-14857,-14678,-14674,
        -14670,-14668, -14663,-14654,-14645,
        -14630,-14594,-14429,-14407,-14399,
        -14384,-14379,-14368,-14355,-14353,
        -14345,-14170,-14159, -14151,-14149,
        -14145,-14140,-14137,-14135,-14125,
        -14123,-14122,-14112,-14109,-14099,
        -14097,-14094,-14092,-14090, -14087,
        -14083,-13917,-13914,-13910,-13907,
        -13906,-13905,-13896,-13894,-13878,
        -13870,-13859,-13847,-13831,-13658, 
        -13611,-13601,-13406,-13404,-13400,
        -13398,-13395,-13391,-13387,-13383,
        -13367,-13359,-13356,-13343,-13340,
        -13329, -13326,-13318,-13147,-13138,
        -13120,-13107,-13096,-13095,-13091,
        -13076,-13068,-13063,-13060,-12888,
        -12875,-12871, -12860,-12858,-12852,
        -12849,-12838,-12831,-12829,-12812,
        -12802,-12607,-12597,-12594,-12585,
        -12556,-12359,-12346, -12320,-12300,
        -12120,-12099,-12089,-12074,-12067,
        -12058,-12039,-11867,-11861,-11847,
        -11831,-11798,-11781,-11604, -11589,
        -11536,-11358,-11340,-11339,-11324,
        -11303,-11097,-11077,-11067,-11055,
        -11052,-11045,-11041,-11038,-11024,
        -11020,-11019,-11018,-11014,-10838,
        -10832,-10815,-10800,-10790,-10780,
        -10764,-10587,-10544,-10533,-10519,
        -10331, -10329,-10328,-10322,-10315,
        -10309,-10307,-10296,-10281,-10274,
        -10270,-10262,-10260,-10256,-10254
    };
        private static string[] pystr = new string[]{"a","ai","an","ang","ao",
        "ba","bai","ban","bang","bao","bei","ben","beng","bi",
        "bian","biao", "bie","bin","bing","bo","bu","ca","cai",
        "can","cang","cao","ce","ceng","cha","chai","chan",
        "chang","chao","che","chen", "cheng","chi","chong",
        "chou","chu","chuai","chuan","chuang","chui","chun",
        "chuo","ci","cong","cou","cu","cuan","cui", "cun",
        "cuo","da","dai","dan","dang","dao","de","deng","di",
        "dian","diao","die","ding","diu","dong","dou","du",
        "duan", "dui","dun","duo","e","en","er","fa","fan",
        "fang","fei","fen","feng","fo","fou","fu","ga","gai",
        "gan","gang","gao", "ge","gei","gen","geng","gong",
        "gou","gu","gua","guai","guan","guang","gui","gun",
        "guo","ha","hai","han","hang", "hao","he","hei",
        "hen","heng","hong","hou","hu","hua","huai","huan",
        "huang","hui","hun","huo","ji","jia","jian", "jiang",
        "jiao","jie","jin","jing","jiong","jiu","ju","juan",
        "jue","jun","ka","kai","kan","kang","kao","ke","ken", 
        "keng","kong","kou","ku","kua","kuai","kuan","kuang",
        "kui","kun","kuo","la","lai","lan","lang","lao","le",
        "lei", "leng","li","lia","lian","liang","liao","lie",
        "lin","ling","liu","long","lou","lu","lv","luan","lue",
        "lun","luo", "ma","mai","man","mang","mao","me","mei",
        "men","meng","mi","mian","miao","mie","min","ming","miu",
        "mo","mou","mu", "na","nai","nan","nang","nao","ne","nei",
        "nen","neng","ni","nian","niang","niao","nie","nin","ning",
        "niu","nong", "nu","nv","nuan","nue","nuo","o","ou","pa",
        "pai","pan","pang","pao","pei","pen","peng","pi","pian",
        "piao","pie", "pin","ping","po","pu","qi","qia","qian",
        "qiang","qiao","qie","qin","qing","qiong","qiu","qu","quan",
        "que","qun", "ran","rang","rao","re","ren","reng","ri","rong",
        "rou","ru","ruan","rui","run","ruo","sa","sai","san","sang", 
        "sao","se","sen","seng","sha","shai","shan","shang","shao",
        "she","shen","sheng","shi","shou","shu","shua", "shuai","shuan",
        "shuang","shui","shun","shuo","si","song","sou","su","suan",
        "sui","sun","suo","ta","tai", "tan","tang","tao","te","teng",
        "ti","tian","tiao","tie","ting","tong","tou","tu","tuan","tui",
        "tun","tuo", "wa","wai","wan","wang","wei","wen","weng","wo",
        "wu","xi","xia","xian","xiang","xiao","xie","xin","xing", 
        "xiong","xiu","xu","xuan","xue","xun","ya","yan","yang","yao",
        "ye","yi","yin","ying","yo","yong","you", "yu","yuan","yue",
        "yun","za","zai","zan","zang","zao","ze","zei","zen","zeng",
        "zha","zhai","zhan","zhang", "zhao","zhe","zhen","zheng",
        "zhi","zhong","zhou","zhu","zhua","zhuai","zhuan","zhuang",
        "zhui","zhun","zhuo", "zi","zong","zou","zu","zuan","zui",
        "zun","zuo"};
         * 
         */
        #endregion


        #region 汉字区位的hash表
        /// <summary>
        /// 汉字的hash表
        /// </summary>
        static void HzQpHash()
        {
            htqp = new System.Collections.Hashtable();
            htqp.Add(-20319, "a");
            htqp.Add(-20317, "ai");
            htqp.Add(-20304, "an");
            htqp.Add(-20295, "ang");
            htqp.Add(-20292, "ao");
            htqp.Add(-20283, "ba");
            htqp.Add(-20265, "bai");
            htqp.Add(-20257, "ban");
            htqp.Add(-20242, "bang");
            htqp.Add(-20230, "bao");
            htqp.Add(-20051, "bei");
            htqp.Add(-20036, "ben");
            htqp.Add(-20032, "beng");
            htqp.Add(-20026, "bi");
            htqp.Add(-20002, "bian");
            htqp.Add(-19990, "biao");
            htqp.Add(-19986, "bie");
            htqp.Add(-19982, "bin");
            htqp.Add(-19976, "bing");
            htqp.Add(-19805, "bo");
            htqp.Add(-19784, "bu");
            htqp.Add(-19775, "ca");
            htqp.Add(-19774, "cai");
            htqp.Add(-19763, "can");
            htqp.Add(-19756, "cang");
            htqp.Add(-19751, "cao");
            htqp.Add(-19746, "ce");
            htqp.Add(-19741, "ceng");
            htqp.Add(-19739, "cha");
            htqp.Add(-19728, "chai");
            htqp.Add(-19725, "chan");
            htqp.Add(-19715, "chang");
            htqp.Add(-19540, "chao");
            htqp.Add(-19531, "che");
            htqp.Add(-19525, "chen");
            htqp.Add(-19515, "cheng");
            htqp.Add(-19500, "chi");
            htqp.Add(-19484, "chong");
            htqp.Add(-19479, "chou");
            htqp.Add(-19467, "chu");
            htqp.Add(-19289, "chuai");
            htqp.Add(-19288, "chuan");
            htqp.Add(-19281, "chuang");
            htqp.Add(-19275, "chui");
            htqp.Add(-19270, "chun");
            htqp.Add(-19263, "chuo");
            htqp.Add(-19261, "ci");
            htqp.Add(-19249, "cong");
            htqp.Add(-19243, "cou");
            htqp.Add(-19242, "cu");
            htqp.Add(-19238, "cuan");
            htqp.Add(-19235, "cui");
            htqp.Add(-19227, "cun");
            htqp.Add(-19224, "cuo");
            htqp.Add(-19218, "da");
            htqp.Add(-19212, "dai");
            htqp.Add(-19038, "dan");
            htqp.Add(-19023, "dang");
            htqp.Add(-19018, "dao");
            htqp.Add(-19006, "de");
            htqp.Add(-19003, "deng");
            htqp.Add(-18996, "di");
            htqp.Add(-18977, "dian");
            htqp.Add(-18961, "diao");
            htqp.Add(-18952, "die");
            htqp.Add(-18783, "ding");
            htqp.Add(-18774, "diu");
            htqp.Add(-18773, "dong");
            htqp.Add(-18763, "dou");
            htqp.Add(-18756, "du");
            htqp.Add(-18741, "duan");
            htqp.Add(-18735, "dui");
            htqp.Add(-18731, "dun");
            htqp.Add(-18722, "duo");
            htqp.Add(-18710, "e");
            htqp.Add(-18697, "en");
            htqp.Add(-18696, "er");
            htqp.Add(-18526, "fa");
            htqp.Add(-18518, "fan");
            htqp.Add(-18501, "fang");
            htqp.Add(-18490, "fei");
            htqp.Add(-18478, "fen");
            htqp.Add(-18463, "feng");
            htqp.Add(-18448, "fo");
            htqp.Add(-18447, "fou");
            htqp.Add(-18446, "fu");
            htqp.Add(-18239, "ga");
            htqp.Add(-18237, "gai");
            htqp.Add(-18231, "gan");
            htqp.Add(-18220, "gang");
            htqp.Add(-18211, "gao");
            htqp.Add(-18201, "ge");
            htqp.Add(-18184, "gei");
            htqp.Add(-18183, "gen");
            htqp.Add(-18181, "geng");
            htqp.Add(-18012, "gong");
            htqp.Add(-17997, "gou");
            htqp.Add(-17988, "gu");
            htqp.Add(-17970, "gua");
            htqp.Add(-17964, "guai");
            htqp.Add(-17961, "guan");
            htqp.Add(-17950, "guang");
            htqp.Add(-17947, "gui");
            htqp.Add(-17931, "gun");
            htqp.Add(-17928, "guo");
            htqp.Add(-17922, "ha");
            htqp.Add(-17759, "hai");
            htqp.Add(-17752, "han");
            htqp.Add(-17733, "hang");
            htqp.Add(-17730, "hao");
            htqp.Add(-17721, "he");
            htqp.Add(-17703, "hei");
            htqp.Add(-17701, "hen");
            htqp.Add(-17697, "heng");
            htqp.Add(-17692, "hong");
            htqp.Add(-17683, "hou");
            htqp.Add(-17676, "hu");
            htqp.Add(-17496, "hua");
            htqp.Add(-17487, "huai");
            htqp.Add(-17482, "huan");
            htqp.Add(-17468, "huang");
            htqp.Add(-17454, "hui");
            htqp.Add(-17433, "hun");
            htqp.Add(-17427, "huo");
            htqp.Add(-17417, "ji");
            htqp.Add(-17202, "jia");
            htqp.Add(-17185, "jian");
            htqp.Add(-16983, "jiang");
            htqp.Add(-16970, "jiao");
            htqp.Add(-16942, "jie");
            htqp.Add(-16915, "jin");
            htqp.Add(-16733, "jing");
            htqp.Add(-16708, "jiong");
            htqp.Add(-16706, "jiu");
            htqp.Add(-16689, "ju");
            htqp.Add(-16664, "juan");
            htqp.Add(-16657, "jue");
            htqp.Add(-16647, "jun");
            htqp.Add(-16474, "ka");
            htqp.Add(-16470, "kai");
            htqp.Add(-16465, "kan");
            htqp.Add(-16459, "kang");
            htqp.Add(-16452, "kao");
            htqp.Add(-16448, "ke");
            htqp.Add(-16433, "ken");
            htqp.Add(-16429, "keng");
            htqp.Add(-16427, "kong");
            htqp.Add(-16423, "kou");
            htqp.Add(-16419, "ku");
            htqp.Add(-16412, "kua");
            htqp.Add(-16407, "kuai");
            htqp.Add(-16403, "kuan");
            htqp.Add(-16401, "kuang");
            htqp.Add(-16393, "kui");
            htqp.Add(-16220, "kun");
            htqp.Add(-16216, "kuo");
            htqp.Add(-16212, "la");
            htqp.Add(-16205, "lai");
            htqp.Add(-16202, "lan");
            htqp.Add(-16187, "lang");
            htqp.Add(-16180, "lao");
            htqp.Add(-16171, "le");
            htqp.Add(-16169, "lei");
            htqp.Add(-16158, "leng");
            htqp.Add(-16155, "li");
            htqp.Add(-15959, "lia");
            htqp.Add(-15958, "lian");
            htqp.Add(-15944, "liang");
            htqp.Add(-15933, "liao");
            htqp.Add(-15920, "lie");
            htqp.Add(-15915, "lin");
            htqp.Add(-15903, "ling");
            htqp.Add(-15889, "liu");
            htqp.Add(-15878, "long");
            htqp.Add(-15707, "lou");
            htqp.Add(-15701, "lu");
            htqp.Add(-15681, "lv");
            htqp.Add(-15667, "luan");
            htqp.Add(-15661, "lue");
            htqp.Add(-15659, "lun");
            htqp.Add(-15652, "luo");
            htqp.Add(-15640, "ma");
            htqp.Add(-15631, "mai");
            htqp.Add(-15625, "man");
            htqp.Add(-15454, "mang");
            htqp.Add(-15448, "mao");
            htqp.Add(-15436, "me");
            htqp.Add(-15435, "mei");
            htqp.Add(-15419, "men");
            htqp.Add(-15416, "meng");
            htqp.Add(-15408, "mi");
            htqp.Add(-15394, "mian");
            htqp.Add(-15385, "miao");
            htqp.Add(-15377, "mie");
            htqp.Add(-15375, "min");
            htqp.Add(-15369, "ming");
            htqp.Add(-15363, "miu");
            htqp.Add(-15362, "mo");
            htqp.Add(-15183, "mou");
            htqp.Add(-15180, "mu");
            htqp.Add(-15165, "na");
            htqp.Add(-15158, "nai");
            htqp.Add(-15153, "nan");
            htqp.Add(-15150, "nang");
            htqp.Add(-15149, "nao");
            htqp.Add(-15144, "ne");
            htqp.Add(-15143, "nei");
            htqp.Add(-15141, "nen");
            htqp.Add(-15140, "neng");
            htqp.Add(-15139, "ni");
            htqp.Add(-15128, "nian");
            htqp.Add(-15121, "niang");
            htqp.Add(-15119, "niao");
            htqp.Add(-15117, "nie");
            htqp.Add(-15110, "nin");
            htqp.Add(-15109, "ning");
            htqp.Add(-14941, "niu");
            htqp.Add(-14937, "nong");
            htqp.Add(-14933, "nu");
            htqp.Add(-14930, "nv");
            htqp.Add(-14929, "nuan");
            htqp.Add(-14928, "nue");
            htqp.Add(-14926, "nuo");
            htqp.Add(-14922, "o");
            htqp.Add(-14921, "ou");
            htqp.Add(-14914, "pa");
            htqp.Add(-14908, "pai");
            htqp.Add(-14902, "pan");
            htqp.Add(-14894, "pang");
            htqp.Add(-14889, "pao");
            htqp.Add(-14882, "pei");
            htqp.Add(-14873, "pen");
            htqp.Add(-14871, "peng");
            htqp.Add(-14857, "pi");
            htqp.Add(-14678, "pian");
            htqp.Add(-14674, "piao");
            htqp.Add(-14670, "pie");
            htqp.Add(-14668, "pin");
            htqp.Add(-14663, "ping");
            htqp.Add(-14654, "po");
            htqp.Add(-14645, "pu");
            htqp.Add(-14630, "qi");
            htqp.Add(-14594, "qia");
            htqp.Add(-14429, "qian");
            htqp.Add(-14407, "qiang");
            htqp.Add(-14399, "qiao");
            htqp.Add(-14384, "qie");
            htqp.Add(-14379, "qin");
            htqp.Add(-14368, "qing");
            htqp.Add(-14355, "qiong");
            htqp.Add(-14353, "qiu");
            htqp.Add(-14345, "qu");
            htqp.Add(-14170, "quan");
            htqp.Add(-14159, "que");
            htqp.Add(-14151, "qun");
            htqp.Add(-14149, "ran");
            htqp.Add(-14145, "rang");
            htqp.Add(-14140, "rao");
            htqp.Add(-14137, "re");
            htqp.Add(-14135, "ren");
            htqp.Add(-14125, "reng");
            htqp.Add(-14123, "ri");
            htqp.Add(-14122, "rong");
            htqp.Add(-14112, "rou");
            htqp.Add(-14109, "ru");
            htqp.Add(-14099, "ruan");
            htqp.Add(-14097, "rui");
            htqp.Add(-14094, "run");
            htqp.Add(-14092, "ruo");
            htqp.Add(-14090, "sa");
            htqp.Add(-14087, "sai");
            htqp.Add(-14083, "san");
            htqp.Add(-13917, "sang");
            htqp.Add(-13914, "sao");
            htqp.Add(-13910, "se");
            htqp.Add(-13907, "sen");
            htqp.Add(-13906, "seng");
            htqp.Add(-13905, "sha");
            htqp.Add(-13896, "shai");
            htqp.Add(-13894, "shan");
            htqp.Add(-13878, "shang");
            htqp.Add(-13870, "shao");
            htqp.Add(-13859, "she");
            htqp.Add(-13847, "shen");
            htqp.Add(-13831, "sheng");
            htqp.Add(-13658, "shi");
            htqp.Add(-13611, "shou");
            htqp.Add(-13601, "shu");
            htqp.Add(-13406, "shua");
            htqp.Add(-13404, "shuai");
            htqp.Add(-13400, "shuan");
            htqp.Add(-13398, "shuang");
            htqp.Add(-13395, "shui");
            htqp.Add(-13391, "shun");
            htqp.Add(-13387, "shuo");
            htqp.Add(-13383, "si");
            htqp.Add(-13367, "song");
            htqp.Add(-13359, "sou");
            htqp.Add(-13356, "su");
            htqp.Add(-13343, "suan");
            htqp.Add(-13340, "sui");
            htqp.Add(-13329, "sun");
            htqp.Add(-13326, "suo");
            htqp.Add(-13318, "ta");
            htqp.Add(-13147, "tai");
            htqp.Add(-13138, "tan");
            htqp.Add(-13120, "tang");
            htqp.Add(-13107, "tao");
            htqp.Add(-13096, "te");
            htqp.Add(-13095, "teng");
            htqp.Add(-13091, "ti");
            htqp.Add(-13076, "tian");
            htqp.Add(-13068, "tiao");
            htqp.Add(-13063, "tie");
            htqp.Add(-13060, "ting");
            htqp.Add(-12888, "tong");
            htqp.Add(-12875, "tou");
            htqp.Add(-12871, "tu");
            htqp.Add(-12860, "tuan");
            htqp.Add(-12858, "tui");
            htqp.Add(-12852, "tun");
            htqp.Add(-12849, "tuo");
            htqp.Add(-12838, "wa");
            htqp.Add(-12831, "wai");
            htqp.Add(-12829, "wan");
            htqp.Add(-12812, "wang");
            htqp.Add(-12802, "wei");
            htqp.Add(-12607, "wen");
            htqp.Add(-12597, "weng");
            htqp.Add(-12594, "wo");
            htqp.Add(-12585, "wu");
            htqp.Add(-12556, "xi");
            htqp.Add(-12359, "xia");
            htqp.Add(-12346, "xian");
            htqp.Add(-12320, "xiang");
            htqp.Add(-12300, "xiao");
            htqp.Add(-12120, "xie");
            htqp.Add(-12099, "xin");
            htqp.Add(-12089, "xing");
            htqp.Add(-12074, "xiong");
            htqp.Add(-12067, "xiu");
            htqp.Add(-12058, "xu");
            htqp.Add(-12039, "xuan");
            htqp.Add(-11867, "xue");
            htqp.Add(-11861, "xun");
            htqp.Add(-11847, "ya");
            htqp.Add(-11831, "yan");
            htqp.Add(-11798, "yang");
            htqp.Add(-11781, "yao");
            htqp.Add(-11604, "ye");
            htqp.Add(-11589, "yi");
            htqp.Add(-11536, "yin");
            htqp.Add(-11358, "ying");
            htqp.Add(-11340, "yo");
            htqp.Add(-11339, "yong");
            htqp.Add(-11324, "you");
            htqp.Add(-11303, "yu");
            htqp.Add(-11097, "yuan");
            htqp.Add(-11077, "yue");
            htqp.Add(-11067, "yun");
            htqp.Add(-11055, "za");
            htqp.Add(-11052, "zai");
            htqp.Add(-11045, "zan");
            htqp.Add(-11041, "zang");
            htqp.Add(-11038, "zao");
            htqp.Add(-11024, "ze");
            htqp.Add(-11020, "zei");
            htqp.Add(-11019, "zen");
            htqp.Add(-11018, "zeng");
            htqp.Add(-11014, "zha");
            htqp.Add(-10838, "zhai");
            htqp.Add(-10832, "zhan");
            htqp.Add(-10815, "zhang");
            htqp.Add(-10800, "zhao");
            htqp.Add(-10790, "zhe");
            htqp.Add(-10780, "zhen");
            htqp.Add(-10764, "zheng");
            htqp.Add(-10587, "zhi");
            htqp.Add(-10544, "zhong");
            htqp.Add(-10533, "zhou");
            htqp.Add(-10519, "zhu");
            htqp.Add(-10331, "zhua");
            htqp.Add(-10329, "zhuai");
            htqp.Add(-10328, "zhuan");
            htqp.Add(-10322, "zhuang");
            htqp.Add(-10315, "zhui");
            htqp.Add(-10309, "zhun");
            htqp.Add(-10307, "zhuo");
            htqp.Add(-10296, "zi");
            htqp.Add(-10281, "zong");
            htqp.Add(-10274, "zou");
            htqp.Add(-10270, "zu");
            htqp.Add(-10262, "zuan");
            htqp.Add(-10260, "zui");
            htqp.Add(-10256, "zun");
            htqp.Add(-10254, "zuo");
            htqp.Add(-10247, "zz");
            //System.Net.Cache["ht"]=ht;
        }
        static void HzSmHash()
        {
            htqp = new System.Collections.Hashtable();
            htqp.Add(-20319, "a");
            htqp.Add(-20283, "b");
            htqp.Add(-19775, "c");
            htqp.Add(-19739, "ch");
            htqp.Add(-19261, "c");
            htqp.Add(-19218, "d");
            htqp.Add(-18710, "e");
            htqp.Add(-18526, "f");
            htqp.Add(-18239, "g");
            htqp.Add(-17922, "h");
            htqp.Add(-17417, "j");
            htqp.Add(-16474, "k");
            htqp.Add(-16212, "l");
            htqp.Add(-15640, "m");
            htqp.Add(-15165, "n");
            htqp.Add(-14922, "o");
            htqp.Add(-14914, "p");
            htqp.Add(-14630, "q");
            htqp.Add(-14149, "r");
            htqp.Add(-14090, "s");
            htqp.Add(-13905, "sh");
            htqp.Add(-13383, "s");
            htqp.Add(-13326, "s");
            htqp.Add(-13318, "t");
            htqp.Add(-12838, "w");
            htqp.Add(-12556, "x");
            htqp.Add(-11847, "y");
            htqp.Add(-11055, "z");
            htqp.Add(-11014, "zh");
            htqp.Add(-10296, "z");
            //System.Net.Cache["ht"]=ht;
        }
        #endregion

        

        /// <summary>
        /// 获得汉字全拼组合
        /// </summary>
        /// <param name="hz"></param>
        /// <returns></returns>
        public static string GetPym(int num)
        {
            if (num < -20319 || num > -10247) return "";
            while (!htqp.ContainsKey(num)) num--;
            return htqp[num].ToString();
        }
        /// <summary>
        /// 获得汉字全拼组合
        /// </summary>
        /// <param name="hz"></param>
        /// <returns></returns>
        public static string GetPym(string hz)
        {
            //汉字拆解
            byte[] Hzbyte = System.Text.Encoding.Default.GetBytes(hz);
            //拼音区位
            int pyqw;
            if (htqp == null)
            {
                HzQpHash();
            }
            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < Hzbyte.Length; i++)
            {
                pyqw = (int)Hzbyte[i];
                if (pyqw > 160)
                {
                    pyqw = pyqw * 256 + Hzbyte[++i] - 65536;
                    ret.Append(GetPym(pyqw));
                }
                else
                {
                    ret.Append((char)pyqw);
                }
            }
            return ret.ToString();
        }

        /// <summary>
        /// 获取声母的函数，
        /// allsm true包含所有的生母 否则只取第一个字母头
        /// </summary>
        /// <param name="num"></param>
        /// <param name="allsm"></param>
        /// <returns></returns>
        public static string GetPysm(int num, bool allsm)
        {
            string ret = "";
            if (num < -20319 || num > -10247) return ret;
            while (!htqp.ContainsKey(num)) num--;
            ret = htqp[num].ToString();
            if (allsm)
            {
                if (ret.IndexOf('h') > 0)
                {
                    ret = ret.Substring(0, 2);
                }
                else
                {
                    ret = ret.Substring(0, 1);
                }
            }
            else
            {
                ret = ret.Substring(0, 1);
            }
            return ret;
        }
       /// <summary>
        /// 获取声母的函数
       /// </summary>
       /// <param name="hz"></param>
       /// <returns></returns>
        public static string GetPysm(string hz)
        {
            return GetPysm(hz, false);
        }
        /// <summary>
        /// 获取声母的函数，
        /// allsm true包含所有的生母 否则只取第一个字母头
        /// </summary>
        /// <param name="num"></param>
        /// <param name="allsm"></param>
        /// <returns></returns>
        public static string GetPysm(string hz, bool allsm)
        {
            //汉字拆解
            byte[] Hzbyte = System.Text.Encoding.Default.GetBytes(hz);
            //拼音区位
            int pyqw;
            if (htqp == null)
            {
                HzSmHash();
            }
            StringBuilder ret = new StringBuilder();
            for (int i = 0; i < Hzbyte.Length; i++)
            {
                pyqw = (int)Hzbyte[i];
                if (pyqw > 160)
                {
                    pyqw = pyqw * 256 + Hzbyte[++i] - 65536;
                    ret.Append(GetPysm(pyqw,allsm));
                }
                else
                {
                    ret.Append((char)pyqw);
                }
            }
            return ret.ToString();
        }
        /// <summary>
        /// 执行DOS命令，返回DOS命令的输出
        /// </summary>
        /// <param name="dosCommand">dos命令</param>
        /// <returns>返回输出，如果发生异常，返回空字符串</returns>
        public static string Execute(string dosCommand)
        {
            return Execute(dosCommand, 60 * 1000);
        }
        /// <summary>
        /// 执行DOS命令，返回DOS命令的输出
        /// </summary>
        /// <param name="dosCommand">dos命令</param>
        /// <param name="milliseconds">等待命令执行的时间（单位：毫秒），如果设定为0，则无限等待</param>
        /// <returns>返回输出，如果发生异常，返回空字符串</returns>
        public static string Execute(string dosCommand, int milliseconds)
        {
            string output = "";     //输出字符串
            if (dosCommand != null && dosCommand != "")
            {
                Process process = new Process();     //创建进程对象
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";      //设定需要执行的命令
                startInfo.Arguments = "/C " + dosCommand;   //设定参数，其中的“/C”表示执行完命令后马上退出
                startInfo.UseShellExecute = false;     //不使用系统外壳程序启动
                startInfo.RedirectStandardInput = false;   //不重定向输入
                startInfo.RedirectStandardOutput = true;   //重定向输出
                startInfo.CreateNoWindow = true;     //不创建窗口
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())       //开始进程
                    {
                        if (milliseconds == 0)
                            process.WaitForExit();     //这里无限等待进程结束
                        else
                            process.WaitForExit(milliseconds);  //这里等待进程结束，等待时间为指定的毫秒
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出
                    }
                }
                catch
                {
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }
        /// <summary>
        /// 显示短语库选择器		
        /// </summary>
        /// <param name="dx">记录表中文名,要和短语库对上，否则没有记录</param>
        /// <param name="sx">属性中文名</param>
        /// <returns></returns>
        public static void SelectDyk(string dx,string sx,MemoEdit txt) {
            //2011.06.20 rabbit edit 
            //2011.10.23 胡建林 edit 
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid=''", dx, sx));
            if (parentObj != null)
            {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txt.EditValue = dlg.ucpJ_dykSelector1.GetSelectedRow().nr;
                }
            }
            else
            {
                MsgBox.ShowWarningMessageBox("短语库中没有找到 记录表中文名为 " + dx + " 属性为 " + sx+" 的记录");
            }
        }
        /// <summary>
        /// 多级短语时使用此方法
        /// </summary>
        /// <param name="dx"></param>
        /// <param name="sx"></param>
        /// <param name="txt">最多4级</param>
        /// <returns></returns>
        public static PJ_dyk SelectDyk(string dx, string sx, params TextEdit[] txt) {
            frmDykSelector dlg = new frmDykSelector();
            PJ_dyk dyk = null;
            PJ_dyk parentObj = Client.ClientHelper.PlatformSqlMap.GetOne<PJ_dyk>(string.Format("where dx='{0}' and sx='{1}' and parentid=''", dx, sx));
            if (parentObj != null) {
                dlg.ucpJ_dykSelector1.ParentObj = parentObj;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK) {

                    dyk = dlg.ucpJ_dykSelector1.GetSelectedRow();
                    int len = txt.Length>4?4:txt.Length;
                    for (int i = 0; i < len; i++) {
                        if (i==0)
                            txt[i].EditValue = dyk.nr;
                        else if (i ==1)
                            txt[i].EditValue = dyk.nr2;
                        else if (i==2)
                            txt[i].EditValue = dyk.nr3;
                        else if (i==3)
                            txt[i].EditValue = dyk.nr4;
                    }
                }
            }
            return dyk;
        }
    }
}
