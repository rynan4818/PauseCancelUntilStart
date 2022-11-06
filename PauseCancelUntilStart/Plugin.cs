using HarmonyLib;
using IPA;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace PauseCancelUntilStart
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        /// <summary>
        /// Use to send log messages through BSIPA.
        /// </summary>
        internal static IPALogger Log { get; private set; }
        private Harmony _harmony;
        public const string HARMONY_ID = "com.github.rynan4818.PauseCancelUntilStart";

        [Init]
        public Plugin(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Debug("Initialized.");
            this._harmony = new Harmony(HARMONY_ID);
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Plugin.Log.Info("OnApplicationStart");
            this._harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");
            this._harmony.UnpatchSelf();
        }

    }
}
