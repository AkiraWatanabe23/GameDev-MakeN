namespace Network
{
    public class NetworkMastersystem
    {
        private NetworkBase[] _systems = default;

        public void Initialize(params NetworkBase[] systems)
        {
            _systems = systems;
            for (int i = 0; i < _systems.Length; i++) { _systems[i]?.SystemSetUp(); }
        }

        public void OnUpdate()
        {
            foreach (NetworkBase system in _systems) { system?.OnUpdate(); }
        }

        public void OnDestroy()
        {
            foreach (NetworkBase system in _systems) { system?.OnDestroy(); }
        }
    }
}
