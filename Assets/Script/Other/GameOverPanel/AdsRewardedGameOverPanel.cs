using UnityEngine;
using YG;

public class AdsRewardedGameOverPanel : MonoBehaviour
{
	[SerializeField] GameObject deathPanel;
	[SerializeField] GameObject helloPanel;

	private void OnEnable() => YandexGame.CloseVideoEvent += Rewarded;
	private void OnDisable() => YandexGame.CloseVideoEvent -= Rewarded;

	private void Rewarded(int id)
	{
		if(id == 1)
        {
			ResetGame();
		}

		if (id == 2)
		{
			ResetGame();
			CubeWave.SetWave(1);
			Core.SaveProgress();
			YandexGame.NewLeaderboardScores("leader", CubeWave.GetWave());
		}
	}

	public void AdsContinueGame()
	{
		YandexGame.RewVideoShow(1);
	}

	public void AdsResetWave()
	{
		YandexGame.RewVideoShow(2);
	}

	private void ResetGame()
    {
		deathPanel.SetActive(false);
		helloPanel.SetActive(true);

		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			Destroy(cube);
		}
	}
}

