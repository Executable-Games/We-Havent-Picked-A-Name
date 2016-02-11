# TODO

No assignments, for now, just a general list of things that need doing

We can move these into GitHub issues tomorrow

### World
  * Organize hierarchy better (it's a mess)
    * Layers will help a lot
    * Should we create a couple controllers (Empty objects) for sharing code?
      * On an as-needed basis, probably, but at the very least it could help
        to have a top-level controller like in combat. We'll probably want a
        shared Timer instance at some point in the World scene.
  * Re-write modal system
    * Implement a basic dialogue box with less cruft
    * ^ That's probably a good starting point
    * We need to be able to attach it to an arbitrary character in a scene and
      have it show up near their head
    * This may require us to add some metadata to character objects about
      the relative pixel locations of parts of their anatomy
  * We should de-couple the Spawning system from the modal system
    * Spawning would be useful, but if it's stuck inside of modal not as much
    * This could also be useful in other scenes
  * Consolidate / Improve trigger system
    * It would be ideal to have a trigger system prefab for easy drag/dropping
    * The code could use a quick review, too
  * "Attach" player character to "ground"
    * Shouldn't be able to zoom off into infinity and beyond anymore
    * At the edge of the "ground" object, the player sprite should "stick"

### Combat
  * Add peggy as a combat character (trivially easy to do)
    * I just kinda got lazy after I had 3 combat characters
    * No real reason for it
  * EFFECTS are something we should have! (Every good RPG has effects)
    * This should be pretty easy
    * An enum of statuses that can be assigned to attacks with a certain
      probability, and then those same statuses can be assigned to Units if they
      stick off of an attack
    * Attack will be most of the work; Effects is just icing on the cake
  * ATTACKS
    * I have an idea for this
    * Since there will be a bunch of different types of 'Moves', we'll work from
      there as a starting point and make a bunch of special-purpose scripts
    * Attack base component, which handles grabbing the health from a target and
      causing health effects, cooldowns, etc - universal stuff
    * MoveList component, which maybe (?) should be a part of `Unit`, which
      will keep track of the Moves that a Unit has access to
    * BasicAttack component
      * An implementation of an Attack that just does some simple damage and
        not much else, has 100% chance to hit, etc.
    * SpecialAttack component
      * An implementation of an Attack that can cause Effects, has variable
        damage (potentially dependent upon Unit level?), has variable accuracy,
        and is in general a lot cooler than BasicAttack but still based on the
        same principle. BasicAttack is a good smoke test; SpecialAttack is what
        we will probably actually use for our characters' Attacks
    * Inside of Scripts there's a Combat folder
      * Inside of Combat we can make an Attacks folder
        * *Inside* of Attacks we can have Unit Type folders
        * And in those folders we can define all the cool attacks different
          units can/do have
        * _yeah, organization, mannn_
        * [size=1]420blazeit[/size] (oh shit this isn't BBCode compatible?)
  * ATTACK SELECTION + UI
    * We need an Attack Selection modal
    * An Attack Selection pointer (like an arrow to the character you are
      selecting an attack for or something to indicate what's what)
    * And code to populate the selection modal, point the pointer, and
      send a message back to the Player Unit as to what attack they should queue
      up
    * This should all be encapsulated in Combat UI
  * TARGETING
    * This occurs in between selecting an attack move and it being 'chosen'
    * You use WASD, arrow keys, whatever to pick which enemy you will target
    * Needs like a UI element to point to the current pending target
    * That should shift when you press arrow keys
    * Etc. simple enough, really
    * YOU SHOULD be able to target party members in addition to enemies
      * based on attack type you should default to either a party member or
        an enemy
      * it will be trivially easy to create healing moves since the CombatHealth
        script has a HEAL change type built in
    * Has to talk to the Selection script to tell it who will be the target
      * Selection script has to kick that information, along with attack
        information, back to the Unit so that it knows what attack to queue
        * CombatController, upon ending the player turn on timeout, should then
          apply player attacks and then trigger enemy AI
  * ENEMY AI
    * Dumb AI is fine
    * Let's get something working to where like 10% of the time the enemy
      doesn't "choose a move" in time and has to wait out the turn
    * Then the other 90% of the time they just launch a BasicAttack
    * This can get more sophisticated with time, but for now that's enough
  * MOAR?
