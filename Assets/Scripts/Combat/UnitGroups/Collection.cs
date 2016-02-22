using System.Collections;
using System.Collections.Generic;

/// Author: Jordan (GitHub: @skorlir)
/// Modified 2/22/16: updates to cycle methods for targeting
/// 2/13/16
namespace Combat.UnitGroups {
    /// <summary>
    /// Units enumerator for easy enumeration of units within a UnitsCollection
    /// </summary>
    public class UnitsEnumerator : IEnumerator<Unit> {
        /// <summary>
        /// Current index of enumeration - should start 'before' the list.
        /// </summary>
        private int _index = -1;

        /// <summary>
        /// Underlying List of Units
        /// </summary>
        private List<Unit> _units;

        /// <summary>
        /// Reset enumerator to start state.
        /// </summary>
        public void Reset () {
            _index = -1;
        }

        /// <summary>
        /// Reset enumerator to end state.
        /// </summary>
        public void ResetReverse () {
            _index = _units.Count;
        }

        // NOTE(jordan): We also don't need this. A no-op is fine.
        void System.IDisposable.Dispose () { }

        /// <summary>
        /// Implementation of IEnumerator<T>.Current
        /// Returns the current Unit in enumeration
        /// </summary>
        public Unit Current {
            get {
                return _units[_index];
            }
        }

        /// <summary>
        /// Implementation of IEnumerator.Current (as required for generic looping)
        /// </summary>
        /// <see cref="Current"/>
        object IEnumerator.Current {
            get {
                return _units[_index];
            }
        }

        /// <summary>
        /// Increments enumerable index
        /// </summary>
        /// <returns>Whether incrementing was successful</returns>
        public bool MoveNext () {
            _index++;
            if (_index >= _units.Count)
                return false;
            return true;
        }

        /// <summary>
        /// Decrements enumerable index
        /// </summary>
        /// <returns>Whether decrementing was successful</returns>
        public bool MoveReverse () {
            _index--;
            if (_index < 0) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Cycles through Units
        /// </summary>
        /// <returns>The next Unit in the cycle</returns>
        public Unit CycleNext () {
            if (MoveNext()) {
                return Current;
            } else {
                Reset();
                MoveNext();
                return Current;
            }
        }

        /// <summary>
        /// Cycles back through Units
        /// </summary>
        /// <returns></returns>
        public Unit CycleReverse () {
            if (MoveReverse()) {
                return Current;
            } else {
                ResetReverse();
                MoveReverse();
                return Current;
            }
        }

        /// <summary>
        /// Cycle through, starting from the Unit given
        /// </summary>
        /// <param name="fromUnit">Unit to start cycling from</param>
        /// <returns>Unit that comes after fromUnit in the cycle</returns>
        public Unit CycleNext (Unit fromUnit) {
            if (_units.Contains(fromUnit)) {
                _index = _units.IndexOf(fromUnit);
            }
            return CycleNext();
        }

        /// <summary>
        /// Cycle back through, starting from the Unit given
        /// </summary>
        /// <param name="fromUnit">Unit to cycle back from</param>
        /// <returns>Unit that comes before fromUnit in cycle</returns>
        public Unit CycleReverse (Unit fromUnit) {
            if (_units.Contains(fromUnit)) {
                _index = _units.IndexOf(fromUnit);
            }
            return CycleReverse();
        }

        /// <summary>
        /// Create a new UnitsEnumerator
        /// </summary>
        /// <param name="units">List of Units to enumerate</param>
        public UnitsEnumerator (List<Unit> units) {
            _units = units;
        }
    }

    /// <summary>
    /// Units collection for easy enumeration of units from a List
    /// </summary>
    public class UnitsCollection : IEnumerable<Unit> {
        /// <summary>
        /// Underlying List of Units
        /// </summary>
        private List<Unit> _units;

        /// <summary>
        /// Get a UnitsEnumerator
        /// </summary>
        /// <returns>UnitsEnumerator for this collection</returns>
        // NOTE(jordan): this is needed because the below are both for foreach and generic/nontyped
        public UnitsEnumerator GetEnumerator () {
            return new UnitsEnumerator(_units);
        }

        /// <summary>
        /// GetEnumerator implementation for IEnumerable<T>
        /// </summary>
        /// <returns>UnitsEnumerator</returns>
        IEnumerator<Unit> IEnumerable<Unit>.GetEnumerator () {
            return GetEnumerator();
        }

        /// <see cref="GetEnumerator"/>
        IEnumerator IEnumerable.GetEnumerator () {
            return GetEnumerator();
        }

        /// <summary>
        /// Create a new enumerable UnitsCollection
        /// </summary>
        public UnitsCollection () {
            _units = new List<Unit>();
        }

        /// <summary>
        /// Add a new Unit
        /// </summary>
        /// <param name="u">Unit to add</param>
        public void Add (Unit u) {
            _units.Add(u);
        }

        /// <summary>
        /// Remove a Unit
        /// </summary>
        /// <param name="u">Unit to remove</param>
        public bool Remove (Unit u) {
            return _units.Remove(u);
        }
    }
}
