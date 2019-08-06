# :video_game: Automation for Gladiatus Game
Automate farming in Gladiatus! Setup your bot with user-friendly GUI!

## Note for employers || recruiters
My biggest experience definitely is in C#/Python and the Selenium framework as you can see here and in the another repositories.
I don't have any commercial experience yet using documentations or test cases.
I'm saying commercial because i did some of them during my studies but i guess that's not the same as in work.
Anyway i guess it won't be hard when someone will provide me tools and examples of ready projects. 
I'm learning quite fast and i like to spend incredible amount of time for learning in IT.
### About future
I'm now rewriting this program to a Java language.
I'm willing to learn Appium and other automation tools in close future or asap if someone will offer me a job which will include some of tools which i don't have currently in my bag of knowledge :) I can create in a short period of time a new project using desired tool/language and prove you that i will get into it pretty fast. 

## Main
![Screenshot](resources/Gladiatus_main_form.JPG)

### :chart_with_upwards_trend: Displays whole data about player
If player is on location where dungeons are unavaliable it will show 0.
### :zzz: Sleep
Deactivate on mouse-move detect.
### :moneybag: Take gold
Starts taking gold from packages.
### :bank: Sell Items
Starts selling items from packages.
### :sparkles: Botting
Determines if program is currently running in normal mode.
### :radio_button: Status of buttons
* Bold -> active
* Regular -> !active

If take gold or sell items action is pressed default scheme is deactivated untill user will turn it on back again.

:heavy_exclamation_mark: By default runs minimized in taskbar as notify icon.

## :wrench: Settings
![Screenshot](resources/Gladiatus_settings_form.JPG)
### :handbag: Backpacks
Determine where program should search described things.
### :clipboard: General
* Expedition
  * Counting enemies from left
* Dungeon
  * Level of dungeon standard/advenced
  * If advenced dungeon is unavaliable then goes to standard one
* Training 
### :no_entry: Limits
* Heal
  * Percentage
* Gold pack
  * Minimum gold to trigger packing gold on guild market
* Gold take
  * Maximum gold to reach (gold taking triggered from main form)
* Food  
  * Maximum number of food pages in packages
* Boosters
  * Maximum number of boosters pages in packages
* Difference 
  * Maximum difference between price and value in auction house
### :bulb: Functions
* Expeditions
* Dungeons
* Event Wars
* Heal
* Food 
  * Buys new food from auction house
* Extract 
  * Specify custom items for extract in settings/extract.txt (e.g. Lucius - write one name per line)
* Sell 
  * Sells items before exit (w/o scrolls, mercenaries, food, additives and event items)
* Auctions 
  * Buys items from auction house before exit (e.g. rings, amulets, food - hides whole gold)
* Boosters 
  * Buys boosters from auction house before exit (useful in 100+ levels for Hades)
* Sleep 
  * Turns sleep mode if user is AFK (if didn't found any mouse-move during bot session)
* Headless 
  * Runs browser in headless mode
* Pack 
  * Buys packs from guild market - based on settings/packages.txt 
* Training 
  * Trains specified skill before exit
* Costume 
  * Takes hades costume if used all points
* Spent rubles 
  * Determines if bot should use rubles during his work (e.g. loading new shops)
* Colours 
  * Specify which colours bot should extract and sell
  
### :radio_button: Buttons
* Save all
* Download packages 
  * Goes to guild market and saves all found items to settings/packages.txt 

## :hammer: Built with
:books: C#

:books: WinForms

:link: [Selenium Framework](https://github.com/SeleniumHQ/selenium)

:link: [Gladiatus Crazy Addon](https://github.com/DinoDevs/GladiatusCrazyAddon)

## :person_with_blond_hair: Authors
:computer: Daniel Sobczak

:mortar_board: Student of WI ZUT Szczecin, Poland

## :pushpin: Future
* Installator
* Auto-Hades

## :trophy: Acknowledgments
* Community of
  * Visual Studio
  * StackOverFlow
  * GitHub
  * Gladiatus Crazy Addon
