using System.Net;
using System.IO;
namespace DownloadImage;

internal class Program
{
    
    static void Main(string[] args)  
    {  
        List<string> _topics = new List<string> {"سگ", "ماشین", "موش", "اسب", "گاو",
            "جنگل","جاده","شن و ماسه","دستمال توالت","کولر آبی","کولر گازی","شلنگ توالت", 
            "فرش","موکت","کابینت","یخچال","ساید بای ساید","فریزر","نوزاد","کودک","خردسال","انسان","نوجوان",
            "سرامیک","موزاییک","مبل","شومینه","بخاری","بخاری نفتی","کتری","قوری","دوش حمام","حمام",
            "وان حمام","توالت ایرانی","توالت فرنگی","پشتی","ساعت دیواری","دریا","ساحل",
            "تابو","موبایل","نوزاد پسر","نوزاد دختر","خردسال دختر","خردسال پسر","کودک پسر","کودک دختر",
            "تلویزیون","گاز","لیف حمام","صابون","مسواک","مشاین ریش تراش","چایی",
            "فنجان چای","درخت سبز","سیب قرمز","پرتغال","سیب سفید","موز",
            "گیلاس میوه","آلبالو","زردآلو","گوجه سبز","هندوانه","کمد کتاب","اسباب بازی خانه",
            "اسباب بازی ماشین","اسباب بازی هواپیما","اسباب بازی ماشین لباسشویی","قابلمه","ماهی تابه",
            "ماهی","اسکناس صد  تومانی","اسکناس هزار تومانی","اسکناس دویست تومانی","اسکناس پانصد تومانی",
            "اسنکناس ده هزار تومانی","اسکناس دویست هزار تومانی","هواپیما","موتور سیکلت",
            "کوه","دماوند","نمای آپارتمان","تخت خواب نوزاد","تخت خواب دو نفره","تخت خواب نوجوان",
            "شرت","سوتین","شلوار","بلوز","پیراهن","خانه سگ","حیاط مدرسه","حیاط خانه","پارکینگ آپارتمان",
            "رخت پنکن","پنکه","کانال کولر","رنگ آبی","رنگ قرمز","رنگ نارنجی",
            "کمد دیواری","کمد لباس","کفش","کتونی","دمپایی مردانه","دمپایی زنانه",
            "تاب وصل شده به بارفیکس","تاب وصل شده به درخت","پادر مسافرتی","تابلو عکس","ساعت دیواری",
            "پاییز","زمستان برفی","زمستان","بهار","شکوفه","برگ سبز درختان","رودخانه",
            "مرغ زنده","خروس","پژو 405","پژو 206","سمند","سورن","دنا","پژو 207","رادیاتور","صندلی","ویلچر",
            "پریز","کلید","عروسک دخترانه","دوچرخه","کفن جنازه","دراور","آینه","پرده",
            "آنتن تلویزیون","شطرنج","منچ","مارپله","موکت طرح دار","پتو",
            "آهو","بز","گوسفند","چراغ خواب","پنجره","چای ساز برقی","ماکروویو","بشقاب","چاقو",
            "سینی","چنگال","دیس","برنج","قرمه سبزی","کباب کوبیده","جوجه کباب","قیمه","هود","آب",
            "لیوان","پارچ","ماهی سرخ شده","میز تلوزیون","لپتاب","کامپیوتر","میز نهار خوری","صندلی چوبی",
            "صندلی فلزی","مبل تخت خوابشو","رنگ سبز","بالکن","بالشت","گل","عسل با موم","عسل","تقویم رومیزی",
            "تقویم دیواری","عینک","گوشواره","گردنبند","شلوار کردی"};
            //"","","","","","","","","","","","","","","","","","","","","",
        var tedad = _topics.Count;
        for (int subjectLopp = 0 ; subjectLopp< tedad ; subjectLopp ++)
        {
            string subject = _topics[subjectLopp];
            string mypath = @"d:\img\";
            if(Directory.Exists(mypath + subject))
            {
                mypath += subject;
            }
            else
            {
                Directory.SetCurrentDirectory(mypath);
                Directory.CreateDirectory(subject);
                mypath += subject;
            }
            List<string> ImageList = GetAllImages(subject);  
            using (WebClient client = new WebClient())  
            {  
                for (int i = 1; i < ImageList.Count; i++)  
                {  
                    client.DownloadFile(new Uri(ImageList[i]), mypath+"\\"+i+".jpg");  
                    Console.WriteLine("downloaded " + mypath+"\\"+i+".jpg");
                }  
            }  
            Task.Delay(5000);
        }
        
    }  

    public static List<string> GetAllImages(string subject)  
    {  
        List<string> ImageList = new List<string>();  
        WebClient x = new WebClient();  

        string source = x.DownloadString(@"https://www.google.com/search?q="+subject+"+عکس&tbm=isch&ved=2ahUKEwizlL6W6sLxAhUE_4UKHS_YBDEQ2-cCegQIABAA&oq=wallpapers+pics&gs_lcp=CgNpbWcQAzICCAAyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAMgIIADICCAA6BwgAELEDEEM6BAgAEENQ3I8FWJ6YBWDsnQVoAHAAeACAAasCiAHYCZIBAzItNZgBAKABAaoBC2d3cy13aXotaW1nwAEB&sclient=img&ei=bjXeYLOlJ4T-lwSvsJOIAw&bih=802&biw=1707");  

        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();  

        document.LoadHtml(source);  

        foreach (var link in document.DocumentNode.Descendants("img").Select(i => i.Attributes["src"]))  
        {  
            ImageList.Add(link.Value);  
        }  
        return ImageList;  
    }  
}

