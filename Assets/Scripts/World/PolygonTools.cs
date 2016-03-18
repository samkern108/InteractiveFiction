using UnityEngine;
using System.Collections;

/*
		PolyK library
		url: http://polyk.ivank.net
		Released under MIT licence.
		
		Copyright (c) 2012 - 2014 Ivan Kuckir

		Permission is hereby granted, free of charge, to any person
		obtaining a copy of this software and associated documentation
		files (the "Software"), to deal in the Software without
		restriction, including without limitation the rights to use,
		copy, modify, merge, publish, distribute, sublicense, and/or sell
		copies of the Software, and to permit persons to whom the
		Software is furnished to do so, subject to the following
		conditions:

		The above copyright notice and this permission notice shall be
		included in all copies or substantial portions of the Software.

		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
		EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
		OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
		NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
		HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
		WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
		FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
		OTHER DEALINGS IN THE SOFTWARE.
		
		19. 5. 2014 - Problem with slicing fixed.
	*/

public class QueryInfo
{
	public Vector2 norm;
	public Vector2 refl;
	public float dist;
	public float edge;
	public Vector2 point;

	public QueryInfo()
	{
		norm = new Vector2 ();
		refl = new Vector2 ();
		dist = 0f;
		edge = 0f;
		point = new Vector2 ();
	}

	public QueryInfo BuildResponse(float dx, float dy, Vector2 a1, Vector2 b1, Vector2 b2, Vector2 c, float edge)
	{
		float nrl = Vector2.Distance(a1, c);
		if(nrl<this.dist)
		{
			float ibl = 1/Vector2.Distance(b1, b2);
			float nx = -(b2.y-b1.y)*ibl;
			float ny =  (b2.x-b1.x)*ibl;
			float ddot = 2*(dx*nx+dy*ny);
			this.dist = nrl;
			this.norm = new Vector2(nx, ny);  
			this.refl = new Vector2(-ddot*nx+dx,-ddot*ny+dy);
			this.edge = edge;
		}
		return this;
	}
}

public static class PolygonTools {

	public static float Raycast(Vector2[] p, Vector2 midpoint, Vector2 direction)
	{
		int l = p.Length - 2;
		Vector2 a1 = new Vector2 (midpoint.x, midpoint.y);
		Vector2 a2 = new Vector2 (midpoint.x+direction.x, midpoint.y+direction.y);
		Vector2 b1 = new Vector2 ();
		Vector2 b2 = new Vector2 ();

		float edge = Mathf.Infinity;
		float dist = Mathf.Infinity;
		Vector2 nisc;
		
		for(var i=0; i<l; i+=2)
		{
			b1 = p[i];  
			b2 = p[i+2];
			nisc = RayLineIntersection(a1, a2, b1, b2);
			if(nisc != new Vector2()) 
				edge = i/2;
		}
		b1.x = b2.x;  b1.y = b2.y;
		b2 = p[0];
		nisc = RayLineIntersection(a1, a2, b1, b2);
		if(nisc != new Vector2()) edge = (p.Length/2)-1;

		return dist;
	}
	
	public static QueryInfo ClosestEdge(Vector2[] poly, Vector2 point)
	{
		int l = poly.Length - 2;
		Vector2 a1 = new Vector2(point.x, point.y);
		Vector2 b1 = new Vector2 ();
		Vector2 b2 = new Vector2 ();
		Vector2 c = new Vector2 ();

		QueryInfo isc = new QueryInfo ();
		isc.dist = Mathf.Infinity;
		
		for(var i=0; i<l; i+=2)
		{
			b1 = poly[i];
			b2 = poly[i+2];
			PointLineDist(a1, b1, b2, i>>1);
		}
		b1.x = b2.x;  b1.y = b2.y;
		b2 = poly [0];
		PointLineDist(a1, b1, b2, l>>1);
		
		var idst = 1/isc.dist;
		isc.norm = new Vector2((point.x-isc.point.x)*idst,(point.y-isc.point.y)*idst);
		return isc;
	}
	
	public static QueryInfo PointLineDist(Vector2 p, Vector2 a, Vector2 b, float edge)
	{
		float x = p.x;
		float y = p.y;
		float x1 = a.x;
		float y1 = a.y;
		float x2 = b.x;
		float y2 = b.y;
		
		float A = x - x1;
		float B = y - y1;
		float C = x2 - x1;
		float D = y2 - y1;
		
		float dot = A * C + B * D;
		float len_sq = C * C + D * D;
		float param = dot / len_sq;
		
		Vector2 xy = new Vector2 ();
		
		if (param < 0 || (x1 == x2 && y1 == y2)) {
			xy = new Vector2(x1, y1);
		}
		else if (param > 1) {
			xy = new Vector2(x2, y2);
		}
		else {
			xy = new Vector2(x1 + param * C, y1 + param * D);
		}
		
		float dx = x - xy.x;
		float dy = y - xy.y;
		float dst = Mathf.Sqrt(dx * dx + dy * dy);

		QueryInfo resp = new QueryInfo ();
		resp.dist = dst;
		resp.edge = edge;
		resp.point = xy;

		return resp;
	}
	
	public static Vector2 RayLineIntersection(Vector2 a1, Vector2 a2, Vector2 b1, Vector2 b2)
	{
		float dax = (a1.x-a2.x);
		float dbx = (b1.x-b2.x);
		float day = (a1.y-a2.y);
		float dby = (b1.y-b2.y);
		
		var Den = dax*dby - day*dbx;
		if (Den == 0) return new Vector2();	// parallel
		
		var A = (a1.x * a2.y - a1.y * a2.x);
		var B = (b1.x * b2.y - b1.y * b2.x);

		var iDen = 1/Den;
		Vector2 I = new Vector2(( A*dbx - dax*B ) * iDen, ( A*dby - day*B ) * iDen);
		
		if(!InRect(I, b1, b2)) return new Vector2();
		if((day>0 && I.y>a1.y) || (day<0 && I.y<a1.y)) return new Vector2(); 
		if((dax>0 && I.x>a1.x) || (dax<0 && I.x<a1.x)) return new Vector2(); 
		return I;
	}

	public static bool InRect(Vector2 a, Vector2 b, Vector2 c)	// a in rect (b,c)
	{
		float minx = Mathf.Min(b.x,c.x);
		float maxx = Mathf.Max(b.x,c.x);
		float miny = Mathf.Min(b.y,c.y); 
		float maxy = Mathf.Max(b.y,c.y);
		
		if	(minx == maxx) return (miny<=a.y && a.y<=maxy);
		if	(miny == maxy) return (minx<=a.x && a.x<=maxx);

		return (minx <= a.x+1e-10 && a.x-1e-10 <= maxx && miny <= a.y+1e-10 && a.y-1e-10 <= maxy) ;		
	}

//  Patrick Mullen on http://alienryderflex.com/polygon/
	private static int polyCorners;
	private static float[] polyX;
	private static float[] polyY;
		
	private static float[] constant;
	private static float[] multiple;
	private static Vector2[] polygon;

	public static void InitializeRoom(Vector2[] poly)
	{
		polygon = poly;
		CollisionPrecalculation();
	}

	private static void CollisionPrecalculation() 
	{
		polyCorners = polygon.Length;
		polyX = new float[polyCorners];
		polyY = new float[polyCorners];
			
		for(int k = 0; k < polyCorners; k++)
		{
			polyX[k] = polygon[k].x;
			polyY[k] = polygon[k].y;
		}
			
		int i, j = polyCorners-1;
		constant = new float[polyCorners];
		multiple = new float[polyCorners];

		for(i=0; i<polyCorners; i++) 
		{
			if(polyY[j]==polyY[i]) 
			{
				constant[i]=polyX[i];
				multiple[i]=0; 
			}
			else 
			{
				constant[i]=polyX[i]-(polyY[i]*polyX[j])/(polyY[j]-polyY[i])+(polyY[i]*polyX[i])/(polyY[j]-polyY[i]);
				multiple[i]=(polyX[j]-polyX[i])/(polyY[j]-polyY[i]); 
			}
			j=i; 
		}
	}

	public static bool PointInPolygon(Vector2 point) 
	{	
		int i, j = polyCorners-1;
		bool oddNodes = false;
		
		for (i=0; i<polyCorners; i++) 
		{
			if ((polyY[i]< point.y && polyY[j]>=point.y || polyY[j]< point.y && polyY[i]>=point.y)) 
			{
				oddNodes^=(point.y*multiple[i]+constant[i]<point.x); 
			}
			j=i; 
		}
		
		return oddNodes; 
	}
}