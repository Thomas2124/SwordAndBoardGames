using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicsController : MonoBehaviour
{
	public void GameGraphics (int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}
}
