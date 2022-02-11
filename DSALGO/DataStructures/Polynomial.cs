using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSALGO.DataStructures;
namespace DSALGO.DataStructures {

   

    public class Polynomial {
        public class Term {
            public double coefficient;
            public int exponent;
            public Term(double coefficient, int exponent) {
                this.coefficient = coefficient;
                this.exponent = exponent;
            }
            public Term(Term term) {
                this.coefficient = term.coefficient;
                this.exponent = term.exponent;
            }
            public override string ToString() {
                return $"{coefficient}x^{exponent}";
            }
        }

        public List<Term> terms;

        public Polynomial(Polynomial poly) {
            terms = poly.terms.ToList();
        }
        public Polynomial() {
            terms = new List<Term>();
        }
        public override string ToString() {
            string s = "";
            foreach (var term in terms) {
                s += term.ToString() + " ";
            }
            return s;
        }
        public double CalcValue(double x) {
            double result = 0;
            foreach (var term in terms) {
                result += term.coefficient * Math.Pow(x, term.exponent);
            }
            return result;
        }
        public void AddTerm(double coefficient, int exponent) {
            for (int i = 0; i < terms.Count; i++) {
                if(exponent == terms[i].exponent) {
                    terms[i].coefficient += coefficient;
                    return;
                }
            }
            terms.Add(new Term(coefficient, exponent));
        }
        public static Polynomial operator +(Polynomial left, Polynomial right) {
            Polynomial result = new Polynomial();
            int CA = left.terms.Count;
            int CB = right.terms.Count;
            int i = 0;
            int j = 0;
            while (i != CA && j != CB) {
                Term tA = left.terms[i];
                Term tB = right.terms[j];
                if (tA.exponent == tB.exponent) {
                    Term term = new Term(tA.coefficient + tB.coefficient, tA.exponent);
                    result.terms.Add(term);
                    i++;
                    j++;
                }
                else if (tA.exponent < tB.exponent) {
                    result.terms.Add(tA);
                    i++;
                }
                else {
                    result.terms.Add(tB);
                    j++;
                }
            }
            // put the remain terms
            while (i != CA) {
                result.terms.Add(left.terms[i]);
                i++;
            }
            while (j != CB) {
                result.terms.Add(right.terms[j]);
                j++;
            }
            return result;
        }
        public static Polynomial operator -(Polynomial left, Polynomial right) {
            Polynomial result = new Polynomial();
            int CA = left.terms.Count;
            int CB = right.terms.Count;
            int i = 0;
            int j = 0;
            while (i != CA && j != CB) {
                Term tA = left.terms[i];
                Term tB = right.terms[j];
                if (tA.exponent == tB.exponent) {
                    Term term = new Term(tA.coefficient - tB.coefficient, tA.exponent);
                    result.terms.Add(term);
                    i++;
                    j++;
                }
                else if (tA.exponent < tB.exponent) {
                    result.terms.Add(tA);
                    i++;
                }
                else {
                    tB.coefficient *= -1;
                    result.terms.Add(tB);
                    j++;
                }
            }
            // put the remain terms
            while (i != CA) {
                result.terms.Add(left.terms[i]);
                i++;
            }
            while (j != CB) {
                result.terms[j].coefficient *= -1;
                result.terms.Add(right.terms[j]);
                j++;
            }
            return result;
        }
    }

}

