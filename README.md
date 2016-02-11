# Great Holy Guacamole, Batman!
## Yes, that's right, we've got a SKELETON for COMBAT
### wut wut

![s/booty/combat](https://media.giphy.com/media/A7mrYIaSrEl20/giphy.gif)
> ^ srs combat gais, am telling u

## Ok so stop flapjacking around and tell us the digs

Here's the skinny on all the diffs:

* There's a new SCENE
  * OMG OMG OM
  * Right, so it's called 'Combat'
    * Whudathunk
  * Click on it in that little "scenes" place where you can put yer grimy
    mouse finger - you know, that FOLDER inside of the PROJECT panel.
* The old "perspecital movement" scene has been renamed
  * Yes, srsly, that was the name
  * The new name of that scene is 'World'
* I have deleted the 'Dialogue scene'
  * And also replaced the dialogue box assets with something hand-drawn
  * It doesn't look _quite_ as out-of-place now
  * The dialogue system, btw, is terrifying
  * We will need to re-write it
* There are a bunch of new *scripts*
  * IT'S LIKE FUCKING CHRISTM
  * Anyway, one of them is this new-finagled deal called 'Timer'
  * Timer has two methods
    * (all times are in seconds)
    * Timer.Every(float|int time, Action thingToDo)
    * Timer.After(float|int time, Action thingToDo)
    * It works pretty well
    * Pls use this, hard-coded timers got really hard to keep track of
      even with only 2-3 of them; that's why I wrote dis
    * DON'T MAKE A NEW TIMER THO
      * It's a singleton
      * It's attached to the 'root' GameObject in the Combat scene
      * (That object, btw, is called 'Combat Controller' ikr so creative)
      * IF you need to use the Timer, and you're like, "but how do I get to
        there," then either use
        * GameObject.Find to get a reference to Combat Controller
        * OR actually don't, you can probably use GetComponentInParent<Timer>()
          to get the Timer directly from Combat Controller
          * Most things are direct children of Combat Controller
        * OR, if you need it from a Unit, you can do:
          * `transform.parent.gameObject.GetComponent<UnitGroupController>().Timer`
          * there's a public reference to the global Timer inside of the
            'Stage,' so you're still using the Combat Controller global
          * There's a straightforward example of this in the `Unit` script
          * It's broken up across multiple lines for readability, of course
* Did you say UNIT? UWOTM8?!
  * THAT'S RIGHT! *COMBAT* UNIT!
  * Right now `Unit` is a stub; it just identifies a unit as being player- or
    enemy-owned
* And related to `Unit`
  * There's a `CombatHealth` script, too
  * It does what it sounds like; it gives the object it is attached to an HP counter
  * You can either heal or damage using it by using the `Heal` and `Damage` methods
    from another script (eg an Attack script, eh? EH?)
  * See? Easy.
* Oh, right, almost forgot
  * There's also a CombatUIController
  * This is one place Timer is currently used in a non-trivial way
  * I implemented a debugging message box for turn timing
    * Right, recall we talked about limiting the number of seconds you have
      to make move decisions in? That's there, it's just ugly right now.
    * Future: let's make it like a progress bar or something
  * The UIController should be able to be extended to handle any amount of UI
    complexity, though it will become necessary to adapt it a bit and probably
    write some UI scripts for new components (this can be used as a bit of a
    starting point for rewriting modals in a better way, for instance)
* And, of course, Combat Controller has its own script
  * chick it out
  * it basically just keeps track of whose turn it currently is, as of rn
  * this will be a good place to keep reusable singletons for our other scripts

So there's a lot of other shit, too, but that's most of it
When we meet up tomorrow we can talk it all over.

Until then! Wop.
