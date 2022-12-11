from datetime import datetime, time
from webbrowser import register,BackgroundBrowser,get
from time import sleep
from win10toast import ToastNotifier
from get_url import math,exersise
from _thread import start_new_thread

today_num = datetime.today().weekday() #number of day start from monday -> 0 - 6
Math = "https://yekta.iut.ac.ir/mod/bigbluebuttonbn/bbb_view.php?action=join&id=203901&bn=39726"
Phisics = "https://nikan.iut.ac.ir/rqhszpvyx6i8/?session=breezbreezwccinuwkgrf2a58g&proto=true"
Chem = "https://nikan.iut.ac.ir/r16ulw3fqhhx/?session=breezbreez5393s4fod7z8xhe8&proto=true"
register("chrome",None,BackgroundBrowser("C:\Program Files\Google\Chrome\Application\chrome.exe"))



def wb_open(url):   
    get("chrome").open_new_tab(url)

def main():
    while True:
        C_time = str(datetime.now().hour) + ":" + str(datetime.now().minute)
        if today_num == 6: #sunday
            if C_time == "7:55":
                math()
        if today_num == 5: #Saturday
            if C_time == "7:55":
                wb_open(Phisics)
            if C_time == "14:50":
                wb_open(Chem)
            if C_time == "16:14":
                wb_open("www.google.com")
        if today_num == 0: #monday
            if C_time == "8:0":
                wb_open(Phisics)
            if C_time == "14:50":
                wb_open(Chem)
            if C_time == "14:56":
                wb_open(Chem)
        if today_num == 1: #Tuesday
            if C_time == "7:55":
                math()
        sleep(60)
start_new_thread(exersise,("",))
main()

