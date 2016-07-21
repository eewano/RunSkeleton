using System;

public delegate void EveHandPLAYSE(object sender, EventArgs e);

public delegate void EveHandGotoStage(object sender, int i);

public delegate void EveHandMoveState(object sender, EventArgs e);

public delegate void EveHandGameOver(object sender, EventArgs e);

public delegate void EveHandRetry(object sender, EventArgs e);

public delegate void EveHandAppearHide(object sender, EventArgs e);

public delegate void EveHandPlayerMotion(object sender, EventArgs e);