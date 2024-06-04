using UnityEngine;

public class GameOverPanelRestartWave : MonoBehaviour
{
	public void ResetWave()
	{
		CubeWave.SetWave(CubeWave.GetWave());

		foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			Destroy(cube);
		}
	}
}
