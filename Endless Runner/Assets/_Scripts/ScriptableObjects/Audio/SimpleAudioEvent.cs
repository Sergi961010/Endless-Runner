using UnityEngine;

namespace TheCreators.Scripts.ScriptableObjects.Audio
{
	[CreateAssetMenu(menuName = "Audio Events/Simple")]
	public class SimpleAudioEvent : AudioEvent
	{
		public AudioClip[] clips;

		public override void Play(AudioSource source)
		{
			if (clips.Length == 0) return;

			source.clip = clips[Random.Range(0, clips.Length)];
			source.Play();
		}
	}
}