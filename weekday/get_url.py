from os import devnull
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from win10toast import ToastNotifier
from bs4 import BeautifulSoup
noti= ToastNotifier()
def main():
    global wd
    FF_options = webdriver.FirefoxOptions()
    FF_options.add_argument('--headless')
    wd = webdriver.Firefox(executable_path="C:/Users/PC/Project/weekday/geckodriver.exe",options=FF_options,service_log_path=devnull)
    wd.get("https://yekta.iut.ac.ir/my/")
    wd.find_element(By.CLASS_NAME,"potentialidp").click()
    wd.find_element(By.ID,"username").send_keys("40017583")
    wd.find_element(By.ID,"password").send_keys("@M1r@rsh1@")
    wd.find_element(By.XPATH,"/html/body/div[3]/main/div/div/section/div/div[2]/form/span/div/button").click()
    return wd.find_elements(By.CLASS_NAME,"courselink ")

def math():
    main()[4].click()
    elm = wd.find_elements(By.CLASS_NAME,"aalink")
    for e in elm: 
        if e.get_attribute('href') == "https://yekta.iut.ac.ir/mod/bigbluebuttonbn/view.php?id=203901":
             smth = e
        else:
            pass
    smth.click()
    buttons = wd.find_element(By.ID,"join_button").click()


def exersise(s):
    main()
    tasks = WebDriverWait(wd, 30).until(
        EC.presence_of_element_located((By.XPATH, """/html/body/div[3]/div[3]/div/div/section[2]/aside/section[3]/div/div/div[1]/div[2]/div/div/div[1]/div/div/div[2]/div/div[1]/div/div/div[1]"""))
    )
    soup = BeautifulSoup(tasks.get_attribute("innerHTML"),"lxml")
    task = soup.find_all("div",attrs={"class":["list-group-item", "flex-column py-2" ,"pl-0 pr-0 border-0"]})
    for x in task:
        time =x.find("small",attrs={"class":["text-right","text-nowrap","ml-1"]})
        name = x.find("small",attrs={"class":["text-muted","text-truncate","mb-0"]})
        noti.show_toast(name.text,time.text,"C:/Users/PC/Project/weekday/favicon.ico",10)
    wd.close()