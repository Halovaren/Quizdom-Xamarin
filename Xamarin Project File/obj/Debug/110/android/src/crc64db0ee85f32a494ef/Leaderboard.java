package crc64db0ee85f32a494ef;


public class Leaderboard
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("IT123P_Final_Course_Assessment_MP.Leaderboard, IT123P_Final_Course_Assessment_MP", Leaderboard.class, __md_methods);
	}


	public Leaderboard ()
	{
		super ();
		if (getClass () == Leaderboard.class)
			mono.android.TypeManager.Activate ("IT123P_Final_Course_Assessment_MP.Leaderboard, IT123P_Final_Course_Assessment_MP", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
