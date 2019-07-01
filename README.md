# Automation for Gladiatus Game
Bot with user-friendly GUI to setup for online game Gladiatus.
## Main
![Screenshot](resources/Gladiatus_main_form.JPG)

* Displays whole data about player,
* Sleep (deactivate on mouse-move),
* Take Gold (takes specified amount of gold),
* Sell Items (sells items, moves them on specified backpack),
* Settings (opens settings GUI, descripted below),
* Botting (determines if bot is currently running in normal mode),
  * bold: activated, regular: deactivated,
  * If Take Gold or Sell Items is pressed Botting is deactivated untill user will turn it on back again.

## Settings
![Screenshot](resources/Gladiatus_settings_form.JPG)
* Logging (hopefully here is everything clear),
* Backpacks (determine which backpack bot should use for specific functions),
  * Food (move from packages found/bought food and heal from there).
* General
  * Expedition (choose which enemy bot should attack),
  * Dungeon (determine which dungeons bot should do),
    * Bot will go to advanced only if will be currently avaliable,
  * Training (choose skill which bot should training on ending work).
* Limits
  * Heal (below which % bot should heal),
  * Gold pack (over which gold bot should search pack items),
  * Gold take (maximum gold level to take out gold),
  * Food (maximum pages of food to buy from auction house),
  * Boosters (maximum pages of boosters to buy from auction house),
  * Difference (maximum difference between price and value in auction house of items).
* Functions
  * Expedition (bot should go to expeditions),
  * Dungeons (bot should go to dungeons),
  * Event Wars (bot should participate in event wars),
  * Heal (bot should heal player on specified limit),
  * Food (bot should buy new food under limit from auction house),
  * Extract (bot should melt items - currently: orange and red),
    * Specify custom items for extract in settings/extract.txt e.g. Lucius (write one name per line),
  * Sell (bot should sell items - currently: all below orange colours),
  * Auctions (bot should pack rest of unpackable gold in auction house items e.g. rings, amulets),
  * Boosters (bot should buy new boosters under limit from auction house),
  * Sleep (turn sleep mode if user is AFK - didn't found any mouse-move during bot session),
  * Headless (run chrome in headless mode),
  * Pack (pack gold - based on .txt file from download packages - on guild market),
  * Training (train specified skill on end),
  * Costume (take hades costume if used whole points),
  * Spent rubles (determine if bot should use rubles during his work e.g. loading new shops).
  * Colours (specify which colours bot should extract/sell),
* Buttons
  * Save all,
  * Download packages (goes to guild market and loads all items to .txt file for pack function).
  

## Built with
* C#
* WinForms
* [Selenium Framework](https://github.com/SeleniumHQ/selenium)
* [Gladiatus Crazy Addon](https://github.com/DinoDevs/GladiatusCrazyAddon)

## Authors
* Daniel Sobczak - whole work - student of WI ZUT SZCZECIN, POLAND.

## Future
* Installator,
* Buying items from auction house (rings, amulets, boosters, food),
* Auto-Hades (tried in the past but unssuccesfully, kinda tricky).

## Acknowledgments
* Community of
  * Visual Studio
  * StackOverFlow
  * GitHub
  * Gladiatus Crazy Addon
