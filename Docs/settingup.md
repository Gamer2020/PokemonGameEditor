
To enable Megas:

	1. Open the config.h files in the src folder. In line 9, change the keystone index to the item index of your liking. Player has to posses that item in order to mega evolve. Build file after the change.

	2. Open your Pokemon Game Editor "roms.ini" or your custom ini.

	3. Make these changes to the ini under BPEE. (Note that the Emerald ROM base Generator will do this for you.)
	
	NumberOfEvolutionTypes=255
	EvolutionName252=Wish Mega Evolution
	Evolution252Param=attack
	EvolutionName251=Mega Evolution
	Evolution251Param=item
	EvolutionName253=Primal Reversion
	Evolution253Param=evolvesbasedonvalue
	EvolutionName255=Revert Megas
	Evolution255Param=evolvesbutnoparms

	
For Regular Stone Mega Evolution:
		a. Open the item editor. Choose an item of your choice to be used as a mega stone. Set its Hold Effect to 139.
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/hold.png)
		b. In the extra section of item, put the index of the target Mega Pokemon (e.g index of Mega Scizor if want your item to behave like Scizorite). Note that you'll have to insert the ID in hex.
		
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/extra.png)
		
		c. Now, open the pokemon editor, choose the mon you want to mega evolve. Then go to the evolution data tab and add an entry there with the 'Condition' being 'Mega evolution' and 'Evolve To' to the Mega Species (e.g Mega Scizor in case of Scizor). For good measure you can also change the required item.
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/evo.png)
		
	For Wish Mega Evolution:
		a. Open the pokemon editor, choose the mon you want to mega evolve. Then go to the evolution data tab and add an entry there with the 'Condition' being 'Wish Mega evolution' and 'Evolve To' to the Mega Species (e.g Mega Rayquaza in case of Rayquaza).
		b. Then set the attack to the one you'd like to use.
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/wish.png)

	For Primal Reversion:
		a. Open the item editor. Choose an item of your choice to be used as a Primal Orb. Set its Hold Effect to 141.
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/hold2.png)
		b. In the extra section of item, put the index of the target Primal Pokemon (e.g index of Primal Groudon if want your item to behave like Red Orb). Note that you'll have to insert the ID in hex.
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/extra.png)
		c. Set the Parameter to 1 for Alpha Reversion and 2 for Omega.
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/param.png)
		d. Now, open the pokemon editor, choose the mon you want to undego Primal Reversion. Then go to the evolution data tab and add an entry there with the 'Condition' being 'Primal Reversion' and 'Evolve To' to the Mega Species (e.g Primal Groudon in case of Groudon). And the set the value to 1 for Alpha or 2 for Omega here too.
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/prime.png)
	5. Make sure to set back the original species as Revert Megas evolution of mega species. (Unless you want your pokemon to stay as mega forever ) (e.g Scizor as Revert Megas evolution of Mega Scizor).
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/revert.png)
	6. To activate Megas in a battle, press the start button while choosing a move. You will hear a sound and the popped out trigger brightens and the evolution happens shortly after.
![alt tag](https://raw.githubusercontent.com/Gamer2020/PokemonGameEditor/master/Screenshots/SettingUpEmEN/mega.png)

Form Changes and Configuration:

	Just open up the config.h file and change the lines accordingly.
