using UnityEngine;
using System.Collections;
using Rotorz.Tile;
using Matcha.Unity;


public class DontLeaveMap : CacheBehaviour
{
	// this class assumes a sprite with a bottom/center pivot point.

	[Tooltip("Amount of sprite allowed to leave the map.")]
	public float leftOffset;
	[Tooltip("Amount of sprite allowed to leave the map.")]
	public float rightOffset;
	[Tooltip("Amount of sprite allowed to leave the map.")]
	public float upperOffset;
	[Tooltip("Amount of sprite allowed to leave the map.")]
	public float lowerOffset;

	private float rightBound;
	private float leftBound;
	private float upperBound;
	private float lowerBound;
	private float spriteWidth;
	private float spriteHeight;
	private TileSystem tileSystem;

	void Start()
	{
		spriteWidth  = GetComponent<Renderer>().bounds.size.x;
		spriteHeight = GetComponent<Renderer>().bounds.size.y;
		tileSystem   = GameObject.Find(TILE_MAP).GetComponent<TileSystem>();

		Vector3 tileSystemSize = new Vector3(
		    tileSystem.ColumnCount * tileSystem.CellSize.x,
		    tileSystem.RowCount * tileSystem.CellSize.y,
		    tileSystem.CellSize.z
		);

		leftBound = 0f;
		rightBound = tileSystemSize.x;
		lowerBound = -(tileSystemSize.y);
		upperBound = 0f;
	}

	void LateUpdate ()
	{
		// check left bound.
		if (transform.position.x - (spriteWidth / 2 - leftOffset) < leftBound)
			transform.SetXPosition(leftBound + (spriteWidth / 2  - leftOffset));

		// check right bound.
		if (transform.position.x + (spriteWidth / 2 - rightOffset) > rightBound)
			transform.SetXPosition(rightBound - (spriteWidth / 2 - rightOffset));

		// check upper bound.
		if (transform.position.y + (spriteHeight - upperOffset) > upperBound)
			transform.SetYPosition(upperBound - (spriteHeight - upperOffset));

		// check lower bound.
		if (transform.position.y - lowerOffset < lowerBound)
		{
			transform.SetYPosition(lowerBound - lowerOffset);
			Messenger.Broadcast<string, Collider2D, int>("player dead", "out of bounds", null, -1);
		}
	}
}