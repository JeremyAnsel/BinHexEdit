
BinHexEdit XWA 2.02 Ship Editor Project Version v1.5
By Jérémy Ansel (JeremyaFr) & Darksaber

* Adds Object Type byte.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v1.4
By Darksaber

* Just rearranged the Pat_LightShips, Pat_MediumShips and Pat_HeavyShips CSV files to be more user friendly.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v1.3
By Darksaber with info by Patrick Darbon

* Allows you change the number of pictures that show in single player for battle and mission

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v1.2
By Darksaber & JC with info by Patrick Darbon

* Adds the ship HUD Icon information for the first 71 slots
* Allow you to show an Icon for a reserved craft slot, instead of having a blank screen (Default Icons ONLY)
* Adds the Map Icons information upto slot 221
* Allows you to change the Map Icons, that you see in the Map View in-game 

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v1.1
By Matt with some stuff found by Michael Anderson (in use in MXvTED).

* Adds S-foils information for the first 50 slots
* Adds slot pointer info, allow you to change the slot a species points to

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v1.0
By dreddnott and Matt via the work of the nCSA guy and Trident.

* Adds all turret information, courtesy of Trident.
* Adds engine sounds for first 65 slots, rack coordinates, and allows all 255 characters of the cockpit file to be entered.
* Attempting to seek and destroy all typos!

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.9
By dreddnott via the work of Trident.

* Adds another weapon enable byte and fixes a big Weapon Duration typo.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.8
By dreddnott via the work of Fingolfin and Trident.

* Adds weapon score and craft targetable bytes.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.7
By dreddnott via the work of Draconious

* Adds weapon behaviour bytes.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.6
By dreddnott via Drakken's work

* Adds a couple bytes to change laser fire ratio. Found by Drakken.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.5
By Hell Raiser with help from Draconious

* Adds a pattern to enable/disable certain weapons.  Found by Hell Raiser.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.4
By Brian with data from Dreddnott and Drakken

* Adds capship laser range values, as well as enable byte(?) in short 24-byte section

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.3
By Hell Raiser with help from Draconious

* Fixed bug, which reported the DSII laser wrong.
* Added lst adding for weapons.  1 is equipment0.lst others are unknown

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.2
By Hell Raiser with help from Draconious

* Allows you to edit the weapon more weapon stats, and change the opt it will use.
* More info on the weapon types you can assign to ships.  Namely adding your edited weapons to your ship.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.1
By Hell Raiser with help from Trident

* Allow you to edit the weapon stats

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.0 A
By Hell Raiser (pointed in right direction from dreddnott

* Allow you to move the "camera" in which you will look out of in the craft

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.9.0
By Zoë Zenobia, courtesy of Jedi Hunter & Demon's effort.

* Enables reserved slots. Thanks again, Jedi Hunter.
* IMPORTANT: To see the enabled new crafts in the Tech Library, you must edit your pilot file. Also, remember to remove the "*" of the enabled species in the shiplist.txt and specdesc.txt.

*************************************************************************

BinHexEdit XWA 2.02 Ship Editor Project Version v0.8.0
By Demon

* This for the new XWA 2.02 patch from LA.
* IMPORTANT:  As far as I can tell, LA kept the fixes from the last patch, so there is no need o assign COMBATSIM cockpit to ships without a cockpit OPT assignment in the Executable.

*************************************************************************

BinHexEdit XWA 2.0 Ship Editor Project Version v0.7.3
By Demon

Added dreddnott's weapon type reference.  Thank you dredd!!

*************************************************************************

BinHexEdit XWA 2.0 Ship Editor Project Version v0.7.2
By Zoë Zenobia, courtesy of Demon's effort.

Demon's cross-reference of cockpit section is wonderful, it also make me think about putting the other info stored in another section of the EXE to this project. In this version, you can easily change the OPT file assigned to the craft, no more replace-the-xwing-with-ewing stuff.
Simply add the lines in the bottom of the LST file, and you can easily switch a X-wing to E-wing or HellcatV or whatever in BinHexEdit. Also, ship type editing is enabled, so you can make use of those assigned but not used freighter slots such as Cargo Tanker 2-5 to put new fighters in. Further explanation is provided in the comment files. Enjoy!

The following is Demon's V0.7.1 disclaimer, I found it very useful in explaining his work, and so I keep it.:)

*************************************************************************

BinHexEdit XWA 2.0 Ship Editor Project (0.7.1) and PATCH
========================================================
(Original by Zoë Zenobia, new features by Demon)
By Demon

In this version of the XWA Ship Edit, I included a cross section of the cockpit files for every slot, even the non-flyable ones, and unused slots.  This provides a quick reference to the cockpit files.  As new cockpit Opts are produced, the values can be easily changed.

A patch for XWA 2.0 to Assign COMBATSIM cockpit to all craft, which do not have a cockpit, assigned.  This allows you to fly non-flyable ships with a cockpit.  Some of the other ships still carried old cockpits from the original X-Wing Game.  For example, the Imperial Star Destroyer had XWING as cockpit, and if you fly it, it had all the appearance of a X-Wing... This corrects it for all ships, as far as I know.

Also, as new ships are enabled, then they already have a default cockpit.  XWA has a neat feature that the HUD adapts to the guns the ships have, so we are not limited like we were in the previous games in which you had to have a cockpit.

To have the Patch written, you must have this new version of the XWA 2 Ship Edit Project installed and running, now in Safe Mode, go to:

- File Write to Binary Write from an existing section Patch and select file "bhep_Cockpit File Cross Ref (Default). CSV"  (If you open the content of the file in a text editor you will see that all it is a just a bunch of offsets, with the type of data and value to write.

The file above is in the same directory as the XWA 2.0 Project.

- Once you get the completion message, then you can check section one, "Cockpit File Cross Ref" and notice that all the new values are in your executable...  neat huh?  That is a feature that I wrote in BinHexEdit so that you could generate and write patches easily.

You know the drill, use at your own risk.  None of this is produced or supported by Lucas Arts or Totally games.

Enjoy and Best Regards!
Demon


=========================================
OTHER KNOWN ISSUES, TRICKS AND SOLUTIONS:
=========================================
I will update these as I find them.

* The file SHIPLIST.TXT contains information of what craft are available for flying.  Modify all Non-flyable ships to Flyable in the list, basically all should have:  "Flyable,Known,Skirmish".

* You can copy a mission file to the \SKIRMISH directory, rename it as "TEMP.TIE", make it read only, and play it with the ship you assign in the Skirmish editor.  Game may crash.  Thanks Cromwell and Saxman.

* Using the trick above, the Death Star Run only seems to accept ships that are normally flyable for proper play...  That is, fighters, and the Corellian Transports.  This seems to be due to the combination of X.OPT, XCOCKPIT.OPT and XEXTERNAL.OPT.  For example, I tried flying the Assault transport, which is flyable if you made the SHIPLIST.TXT changes, and you assigned the Combatsimcockpit.opt to it.  Once I copied Assaulttransport.opt into Assaulttransportexterior and Combatsimcockpit.opt into Assaulttrasportcockpit.opt, and performed the change in the executable, the mission sort of started, showing part of the outside graphic, and crashed in a second.  Before the game would not crash, but you could not see any outside graphics, if you had another transport, and you tried to target it, then PC would crash.  This does not make sense because I flew the TIE Defender in the DS Run with 2 wing mates, and everything was fine.  Thanks, me!

* You can turn around and fly in the outside of the Death Star, by decelerating considerably right at the first tunnel split when you get the message "we need to go the long way".  Turn your ship parallel to the right wall when you are getting to the split, and go about 40-50% throttle, now pull back hard, and you will most likely hit the other wall but not enough to kill you, now fly the opposite way, and you will see the entrance.  You will loose the mission but you will be able to see what the Death Star is...  It is a small flat square surface, kind of like the original trench by Lt. Hag, encased in a square, only there are no bounds and if you fly to one of the non-textured zones, it is freaky, like flying in a void, and if you go far enough, you can see parts of the core and laser gun chamber at about 30-40Km.  Thanks me!! he he.
