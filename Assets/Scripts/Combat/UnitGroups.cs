using System.Collections;
using System.Collections.Generic;

namespace UnitGroups {
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
        /// Implementation of IEnumerator.Current (as required, apparently)
        /// </summary>
        /// <see cref="Current"/>
        object IEnumerator.Current {
            get {
                return _units[_index];
            }
        }

        /// <summary>
        /// MoveToNextIndex will increment the enumerable index and wrap back to front when the list is exhausted
        /// </summary>
        private void MoveToNextIndex () {
            _index++;
            if (_index >= _units.Count)
                _index = 0;
        }

        /// <summary>
        /// Increments enumerable index and 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext () {
            MoveToNextIndex();
            return true;
        }

        /// <summary>
        /// Cycles through
        /// </summary>
        /// <returns></returns>
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
        /// Cycle through, starting from the Unit given
        /// </summary>
        /// <param name="fromUnit">Unit to start cycling from</param>
        /// <returns></returns>
        public Unit CycleNext (Unit fromUnit) {
            if (_units.Contains(fromUnit)) {
                _index = _units.IndexOf(fromUnit) - 1;
            }
            return CycleNext();
        }

        /// <summary>
        /// Create a new enumerable group of Units
        /// </summary>
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
        public UnitsEnumerator Enumerator () {
            return new UnitsEnumerator(_units);
        }

        /// <summary>
        /// GetEnumerator implementation for IEnumerable<T>
        /// </summary>
        /// <returns>UnitsEnumerator</returns>
        public IEnumerator<Unit> GetEnumerator () {
            return new UnitsEnumerator(_units);
        }

        /// <see cref="GetEnumerator"/>
        IEnumerator IEnumerable.GetEnumerator () {
            return new UnitsEnumerator(_units);
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
